using System;
using System.Collections.Generic;
using UnityEngine;

namespace Db.PickupItems.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(PickupItemsBase), fileName = nameof(PickupItemsBase))]
    public class PickupItemsBase : ScriptableObject, IPickupItemsBase
    {
        [SerializeField] private List<PickupItemVo> items;

        public List<PickupItemVo> Items => items;

        public PickupItemVo GetItem(EPickupItemType type)
        {
            foreach (var item in items)
            {
                if (item.Type == type)
                {
                    return item;
                }
            }

            throw new NullReferenceException();
        }
    }
}