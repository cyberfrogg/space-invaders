using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
    [Game]
    [Event(EventTarget.Self)]
    public class ScoreIndicatorComponent : IComponent
    {
        public int Score;
    }
}