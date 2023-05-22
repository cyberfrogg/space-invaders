using System.Collections.Generic;
using Ecs.Views.Linkable.Impl;
using UnityEngine;

namespace Game.Utils
{
    public class GameField : MonoBehaviour
    {
        [SerializeField] private PlayerView _player;
        [SerializeField] private List<EnemyView> _enemies;
        
        public PlayerView PlayerView => _player;
        public List<EnemyView> Enemies => _enemies;
    }
}