using Ecs.Core.Interfaces;
using Ecs.Utils;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using JCMG.EntitasRedux;
using Zenject;

namespace Ecs.Game.Systems.Bullet
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 300, nameof(EFeatures.Shooting))]
    public class BulletMovementSystem : IUpdateSystem
    {
        private readonly ITimeProvider _timeProvider;
        private static readonly ListPool<GameEntity> ListPool = ListPool<GameEntity>.Instance;
        
        private readonly IGroup<GameEntity> _bulletsGroup;
        
        public BulletMovementSystem(
            GameContext game,
            ITimeProvider timeProvider
            )
        {
            _timeProvider = timeProvider;
            _bulletsGroup = game.GetGroup(GameMatcher.AllOf(GameMatcher.Bullet).NoneOf(GameMatcher.Destroyed));
        }

        public void Update()
        {
            var buffer = ListPool.Spawn();
            _bulletsGroup.GetEntities(buffer);
                
            foreach (var bullet in buffer)
            {
                MoveBullet(bullet);
            }
                
            ListPool.Despawn(buffer);
        }

        private void MoveBullet(GameEntity bullet)
        {
            var bulletPosition = bullet.Position.Value;

            bulletPosition += bullet.Velocity.Value * _timeProvider.DeltaTime; 
            
            bullet.ReplacePosition(bulletPosition);
        }
    }
}