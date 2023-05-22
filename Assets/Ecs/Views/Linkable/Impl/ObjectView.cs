using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
	public class ObjectView : LinkableView, IPositionAddedListener, ILocalPositionAddedListener, IRotationAddedListener
	{
		public override void Link(IEntity entity, IContext context)
		{
			base.Link(entity, context);
			var e = (GameEntity)entity;
			e.AddPositionAddedListener(this);
			e.AddLocalPositionAddedListener(this);
			e.AddRotationAddedListener(this);
			e.AddTransform(transform);

			if (e.HasLocalPosition)
				OnLocalPositionAdded(e, e.LocalPosition.Value);

			if (e.HasPosition)
				OnPositionAdded(e, e.Position.Value);

			if (e.HasRotation)
				OnRotationAdded(e, e.Rotation.Value);
		}

		public virtual void OnPositionAdded(GameEntity entity, Vector3 value)
		{
			transform.position = value;
			SetEntityLocalPosition(entity);
		}

		public virtual void OnRotationAdded(GameEntity entity, Quaternion value)
		{
			transform.rotation = value;
		}

		public void OnLocalPositionAdded(GameEntity entity, Vector3 value)
		{
			transform.localPosition = value;
			SetEntityPosition(entity);
		}

		private void SetEntityPosition(GameEntity entity)
		{
			if (!entity.HasPosition)
				entity.AddPosition(transform.position);
			else
				entity.Position.Value = transform.position;
		}

		private void SetEntityLocalPosition(GameEntity entity)
		{
			if (!entity.HasLocalPosition)
				entity.AddLocalPosition(transform.localPosition);
			else
				entity.LocalPosition.Value = transform.localPosition;
		}
	}
}