using Ecs.Managers;
using JCMG.EntitasRedux;

namespace Ecs.Action.Components.Shoot
{
    [Action]
    public class ShootComponent : IComponent
    {
        public Uid Owner;
    }
}