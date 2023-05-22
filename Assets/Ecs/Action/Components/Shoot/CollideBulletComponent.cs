using JCMG.EntitasRedux;

namespace Ecs.Action.Components.Shoot
{
    [Action]
    public class CollideBulletComponent : IComponent
    {
        public int BulletHash;
        public int OtherHash;
    }
}