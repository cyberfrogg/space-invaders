using Db.PickupItems;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
    [Game]
    public class PickupItemComponent : IComponent
    {
        public EPickupItemType Type;
    }
}