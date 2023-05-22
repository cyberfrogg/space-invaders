using Ecs.Utils;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
    public class PlayerView : ObjectView
    {
        [SerializeField] private PlayerParameters playerParameters;
        [SerializeField] private Transform bulletSpawnPoint;

        public PlayerParameters PlayerParameters => playerParameters;
        public Transform BulletSpawnPoint => bulletSpawnPoint;
    }
}