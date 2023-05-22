using System;
using System.Collections.Generic;
using UnityEngine;

namespace Db.Bullet.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(BulletParametersBase), fileName = nameof(BulletParametersBase))]
    public class BulletParametersBase : ScriptableObject, IBulletParametersBase
    {
        [SerializeField] private List<BulletVo> _allBullets;

        public List<BulletVo> AllBullets => _allBullets;

        public BulletVo GetBullet(EBulletType bulletType)
        {
            foreach (var bullet in _allBullets)
            {
                if (bullet.Type == bulletType)
                    return bullet;
            }

            throw new NullReferenceException($"Bullet of type {bulletType} not found!");
        }
    }
}