using Db.Bullet;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
    [Game]
    [Event(EventTarget.Any)]
    public class ActiveBulletTypeComponent : IComponent
    {
        public EBulletType Value;
    }
}