using System;
using Db.Bullet;
using UnityEngine.Serialization;

namespace Db.PickupItems
{
    [Serializable]
    public struct PickupItemVo
    {
        public EPickupItemType Type;
        public EBulletType ApplyActiveBulletType;
        public float InitialSpeed;
        public string PrefabName;
        [FormerlySerializedAs("Radius")] public float PickupRadius;
    }
}