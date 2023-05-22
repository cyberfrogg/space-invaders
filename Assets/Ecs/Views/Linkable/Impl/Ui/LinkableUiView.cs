using JCMG.EntitasRedux;
using SimpleUi.Abstracts;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl.Ui
{
    public abstract class LinkableUiView<TEntity> : UiView, ILinkableUi<TEntity>
        where TEntity : class, IEntity
    {
        private TEntity _entity;
        private bool _destroyed;

        public int Hash => transform.GetHashCode();
        public Transform Transform => transform;
        public int UnityInstanceId => gameObject.GetInstanceID();

        public void Link(IEntity entity, IContext context)
        {
            _entity = (TEntity)entity;
            _entity.OnDestroyEntity += OnDestroyEntity;
            Listen(_entity);
        }

        private void OnDestroyEntity(IEntity entity)
        {
            if (!_destroyed)
                Reset();
            if (_entity != null)
                _entity.OnDestroyEntity -= OnDestroyEntity;
            _entity = null;
        }

        public void Unlink()
        {
            if (_entity == null)
                return;
            Unlisten(_entity);
            OnDestroyEntity(_entity);
        }

        void ILinkableUi<TEntity>.Listen(TEntity entity)
        {
            Listen(entity);
        }

        void ILinkableUi<TEntity>.Unlisten(TEntity entity)
        {
            Unlisten(entity);
        }

        void ILinkableUi<TEntity>.Reset()
        {
            Reset();
        }

        protected abstract void Listen(TEntity entity);

        protected abstract void Unlisten(TEntity entity);

        protected abstract void Reset();

        private void OnDestroy()
        {
            _destroyed = true;
            if (_entity != null)
                OnDestroyEntity(_entity);
        }
    }
}