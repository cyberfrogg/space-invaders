using System;
using Db.Bullet;

namespace Ecs.Utils
{
    [Serializable]
    public struct PlayerParameters
    {
        public float Speed;
        public EBulletType InitialActiveBulletType;
    }
}