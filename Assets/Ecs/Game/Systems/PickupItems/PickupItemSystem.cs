using Db.PickupItems;
using Ecs.Utils;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using JCMG.EntitasRedux;
using Zenject;

namespace Ecs.Game.Systems.PickupItems
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 300, nameof(EFeatures.PickupItems))]
    public class PickupItemSystem : IUpdateSystem
    {
        private readonly GameContext _game;
        private readonly IPickupItemsBase _pickupItemsBase;
        private static readonly ListPool<GameEntity> ListPool = ListPool<GameEntity>.Instance;
        
        private readonly IGroup<GameEntity> _pickupItemsGroup;

        public PickupItemSystem(
            GameContext game,
            IPickupItemsBase pickupItemsBase
            )
        {
            _game = game;
            _pickupItemsBase = pickupItemsBase;
            _pickupItemsGroup = game.GetGroup(GameMatcher.AllOf(GameMatcher.PickupItem).NoneOf(GameMatcher.Destroyed));
        }

        public void Update()
        {
            var buffer = ListPool.Spawn();
            _pickupItemsGroup.GetEntities(buffer);
                
            foreach (var item in buffer)
            {
                PickupItem(item);
            }
                
            ListPool.Despawn(buffer);
        }

        private void PickupItem(GameEntity item)
        {
            var distanceToPlayerSqrt = (item.Position.Value - _game.PlayerEntity.Position.Value).sqrMagnitude;
            var itemVo = _pickupItemsBase.GetItem(item.PickupItem.Type);

            if (distanceToPlayerSqrt <= itemVo.PickupRadius * itemVo.PickupRadius)
            {
                _game.PlayerEntity.ReplaceActiveBulletType(itemVo.ApplyActiveBulletType);
                item.IsDestroyed = true;
            }
        }
    }
}