using System;
using UnityEngine;

namespace Db.Bullet
{
    [Serializable]
    public struct BulletVo
    {
        public EBulletType Type;
        public string PrefabName;
        public float DespawnDelay;
        public float Damage;
        public Vector3 InitialVelocity;
    }
}