using JCMG.EntitasRedux;
using UnityEditor;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
	[RequireComponent(typeof(EntityLink))]
	public abstract partial class LinkableView : MonoBehaviour, ILinkable, ILinkRemovedListener
	{
		[SerializeField] private EntityLink entityLink;
		
		private GameEntity _entity;
		private bool _entityDestroyed;
		private bool _destroyed;
		protected bool Destroyed => _destroyed;

		public int Hash => transform.GetHashCode();

		public Transform Transform => !_destroyed ? transform : null;

		public virtual void Link(IEntity entity, IContext context)
		{
			_entityDestroyed = false;
			_entity = (GameEntity)entity;
			entityLink.Link(_entity);
			_entity.OnDestroyEntity += OnDestroyEntity;
			_entity.AddLinkRemovedListener(this);
		}

		private void OnDestroyEntity(IEntity entity)
		{
			_entityDestroyed = true;
			entity.OnDestroyEntity -= OnDestroyEntity;

			if (entityLink.Entity != null)
				entityLink.Unlink();

			if (!_destroyed)
				DestroyObject();
		}

		protected virtual void DestroyObject()
		{
#if UNITY_EDITOR
			if (EditorApplication.isPlaying)
				Destroy(gameObject);
			else
				DestroyImmediate(gameObject);
#else
			Destroy(gameObject);
#endif
		}

		private void OnDestroy()
		{
			_destroyed = true;
			if (!_entityDestroyed && _entity != null)
				OnDestroyEntity(_entity);

			InternalOnDestroy();
		}

		protected virtual void InternalOnDestroy()
		{
		}

		public void OnLinkRemoved(GameEntity entity)
		{
			OnDestroyEntity(entity);
		}
	}
}