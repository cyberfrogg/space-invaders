using System.Collections.Generic;
using Game.Utils;

namespace Db.Cat
{
    public interface ICatInteractionParametersBase
    {
        List<CatInteractionVo> Interactions { get; }
        CatInteractionVo GetInteraction(ECatInteractionType type);
    }
}