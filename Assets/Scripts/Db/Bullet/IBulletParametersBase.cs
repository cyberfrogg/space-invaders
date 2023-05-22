using System.Collections.Generic;

namespace Db.Bullet
{
    public interface IBulletParametersBase
    {
        List<BulletVo> AllBullets { get; }
        BulletVo GetBullet(EBulletType bulletType);
    }
}