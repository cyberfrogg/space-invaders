using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Action.Components
{
    [Action]
    public class MoveComponent : IComponent
    {
        public Vector2 Direction;
    }
}