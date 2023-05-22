using System;

namespace Ecs.Utils
{
    [Serializable]
    public struct EnemyParameters
    {
        public EEnemyType EnemyType;
        public float MaxHealth;
        public int ScoreForKill;
    }
}