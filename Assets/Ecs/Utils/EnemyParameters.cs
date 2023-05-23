using System;
using UnityEngine;

namespace Ecs.Utils
{
    [Serializable]
    public struct EnemyParameters
    {
        public EEnemyType EnemyType;
        public float MaxHealth;
        public int ScoreForKill;
        [Range(0, 1f)] public float ItemDropChance;
    }
}