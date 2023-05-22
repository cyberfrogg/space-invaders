using Ecs.Utils;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
    public class EnemyView : ObjectView
    {
        [SerializeField] private EnemyParameters enemyParameters;
        
        private GameEntity _self;
        
        public override void Link(IEntity entity, IContext context)
        {
            _self.AddEnemy(enemyParameters.EnemyType);
            _self.AddEnemyParameters(enemyParameters);
            
            
            base.Link(entity, context);
        }
    }
}