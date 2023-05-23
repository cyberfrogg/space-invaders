using Ecs.Utils;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
    public class EnemyView : ObjectView,
        IDeadAddedListener,
        IDeadRemovedListener
    {
        [SerializeField] private EnemyParameters enemyParameters;
        
        public EnemyParameters EnemyParameters => enemyParameters;
        
        private GameEntity _self;

        public override void Link(IEntity entity, IContext context)
        {
            _self = (GameEntity)entity;
            
            base.Link(entity, context);
            
            _self.AddDeadAddedListener(this);
            _self.AddDeadRemovedListener(this);
        }

        public void OnDeadAdded(GameEntity entity)
        {
            gameObject.SetActive(false);
        }

        public void OnDeadRemoved(GameEntity entity)
        {
            gameObject.SetActive(true);
        }
    }
}