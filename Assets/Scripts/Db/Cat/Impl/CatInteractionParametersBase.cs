using System;
using System.Collections.Generic;
using Game.Utils;
using Game.Utils.Drawers;
using UnityEngine;

namespace Db.Cat.Impl
{
    [CreateAssetMenu(menuName = "Settings/Cat/" + nameof(CatInteractionParametersBase), fileName = nameof(CatInteractionParametersBase))]
    public class CatInteractionParametersBase : ScriptableObject, ICatInteractionParametersBase
    {
        [KeyValueFormat("{1} - {0}", nameof(CatInteractionVo.InteractionType), nameof(CatInteractionVo.MoodAddValue))] 
        [SerializeField] private List<CatInteractionVo> _interactions;

        public List<CatInteractionVo> Interactions => _interactions;
        
        public CatInteractionVo GetInteraction(ECatInteractionType type)
        {
            foreach (var interaction in Interactions)
            {
                if (interaction.InteractionType == type)
                {
                    return interaction;
                }
            }

            throw new NullReferenceException($"{nameof(CatInteractionVo)} not found for {type} ");
        }
    }
}