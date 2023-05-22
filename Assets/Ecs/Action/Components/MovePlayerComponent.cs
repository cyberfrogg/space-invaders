using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Action.Components
{
    [Action]
    public class MovePlayerComponent : IComponent
    {
        public Vector2 Direction;
    }
}