using Ecs.Utils;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
    [Game]
    public class EnemyComponent : IComponent
    {
        public EEnemyType Value;
    }
}