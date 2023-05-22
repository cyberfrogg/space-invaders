using System.Collections.Generic;
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

        public CollideBulletSystem(
            ActionContext action,
            ILinkedEntityRepository linkedEntityRepository
            ) : base(action)
        {
            _linkedEntityRepository = linkedEntityRepository;
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
            otherHealth -= bullet.Bullet.BulletVo.Damage;
            other.ReplaceHealth(otherHealth);

            bullet.IsDestroyed = true;
        }
    }
}