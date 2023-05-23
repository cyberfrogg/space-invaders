using Ecs.Core.Interfaces;
using Ecs.Utils;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using JCMG.EntitasRedux;
using Zenject;

namespace Ecs.Game.Systems.PickupItems
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 300, nameof(EFeatures.PickupItems))]
    public class PickupItemsMovementSystem : IUpdateSystem
    {
        private static readonly ListPool<GameEntity> ListPool = ListPool<GameEntity>.Instance;
        private readonly ITimeProvider _timeProvider;
        
        private readonly IGroup<GameEntity> _pickupItemsGroup;
        
        public PickupItemsMovementSystem(
            GameContext game,
            ITimeProvider timeProvider
        )
        {
            _timeProvider = timeProvider;
            _pickupItemsGroup = game.GetGroup(GameMatcher.AllOf(GameMatcher.PickupItem).NoneOf(GameMatcher.Destroyed));
        }

        public void Update()
        {
            var buffer = ListPool.Spawn();
            _pickupItemsGroup.GetEntities(buffer);
                
            foreach (var item in buffer)
            {
                MovePickupItem(item);
            }
                
            ListPool.Despawn(buffer);
        }

        private void MovePickupItem(GameEntity item)
        {
            var itemPosition = item.Position.Value;

            itemPosition += item.Velocity.Value * _timeProvider.DeltaTime; 
            
            item.ReplacePosition(itemPosition);
        }
    }
}