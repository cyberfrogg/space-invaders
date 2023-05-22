using Ecs.Utils;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
    public class PlayerView : ObjectView
    {
        [SerializeField] private PlayerParameters playerParameters;
        [SerializeField] private Transform bulletSpawnPoint;

        public Transform BulletSpawnPoint => bulletSpawnPoint;
        
        private GameEntity _self;
        
        public override void Link(IEntity entity, IContext context)
        {
            _self = (GameEntity)entity;
            
            _self.AddPlayerParameters(playerParameters);
            _self.AddActiveBulletType(playerParameters.InitialActiveBulletType);
            
            base.Link(entity, context);
        }
    }
}