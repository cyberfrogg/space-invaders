
using JCMG.EntitasRedux;

namespace Ecs.Action.Components
{
    [Action]
    public class ChangeScoreComponent : IComponent
    {
        public int Value;
    }
}