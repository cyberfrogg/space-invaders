using System.Collections.Generic;

namespace Db.PickupItems
{
    public interface IPickupItemsBase
    {
        List<PickupItemVo> Items { get; }
        PickupItemVo GetItem(EPickupItemType type);
    }
}