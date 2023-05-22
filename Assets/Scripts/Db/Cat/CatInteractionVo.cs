using System;
using Game.Utils;
using UnityEngine;

namespace Db.Cat
{
    [Serializable]
    public struct CatInteractionVo
    {
        public ECatInteractionType InteractionType;
        [Tooltip("Adds or decreases mood:")] public float MoodAddValue;
    }
}