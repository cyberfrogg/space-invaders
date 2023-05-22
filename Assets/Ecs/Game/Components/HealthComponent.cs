using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
    [Game]
    [Event(EventTarget.Self)]
    [Event(EventTarget.Self, EventType.Removed)]
    public class HealthComponent : IComponent
    {
        public float Value;
    }
}