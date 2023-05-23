using System.Collections.Generic;
using Db.Bullet;
using Ecs.Core.Systems;
using Ecs.Utils;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using JCMG.EntitasRedux;

namespace Ecs.Action.Systems.Shoot
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 900, nameof(EFeatures.Shooting))]
    public class CollideBulletSystem : AReactiveSystemWithPool<ActionEntity>
    {
        private readonly ILinkedEntityRepository _linkedEntityRepository;
        private readonly IBulletParametersBase _bulletParametersBase;

        public CollideBulletSystem(
            ActionContext action,
            ILinkedEntityRepository linkedEntityRepository,
            IBulletParametersBase bulletParametersBase
            ) : base(action)
        {
            _linkedEntityRepository = linkedEntityRepository;
            _bulletParametersBase = bulletParametersBase;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context)
            => context.CreateCollector(ActionMatcher.CollideBullet);

        protected override bool Filter(ActionEntity entity)
            => entity.HasCollideBullet && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> actions)
        {
            foreach (var action in actions)
            {
                action.IsDestroyed = true;
                
                var bullet = _linkedEntityRepository.Get(action.CollideBullet.BulletHash);
                var other = _linkedEntityRepository.Get(action.CollideBullet.OtherHash);
                
                if(bullet == null || other == null)
                    continue;
                
                if(!other.HasEnemy)
                    continue;

                OnCollision(bullet, other);
            }
        }

        private void OnCollision(GameEntity bullet, GameEntity other)
        {
            var otherHealth = other.Health.Value;
            var bulletVo = _bulletParametersBase.GetBullet(bullet.Bullet.Type);
            otherHealth -= bulletVo.Damage;
            other.ReplaceHealth(otherHealth);

            bullet.IsDestroyed = true;
        }
    }
}