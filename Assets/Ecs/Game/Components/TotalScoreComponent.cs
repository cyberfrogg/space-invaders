using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
    [Game]
    [Unique]
    [Event(EventTarget.Any)]
    public class TotalScoreComponent : IComponent
    {
        public int Value;
    }
}