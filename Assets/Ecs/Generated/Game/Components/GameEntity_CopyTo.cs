//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using JCMG.EntitasRedux;

public partial class GameEntity
{
	/// <summary>
	/// Copies <paramref name="component"/> to this entity as a new component instance.
	/// </summary>
	public void CopyComponentTo(IComponent component)
	{
		#if !ENTITAS_REDUX_NO_IMPL
		if (component is Ecs.Common.Components.DestroyedComponent Destroyed)
		{
			IsDestroyed = true;
		}
		else if (component is Ecs.Common.Components.ObjectTypeComponent ObjectType)
		{
			CopyObjectTypeTo(ObjectType);
		}
		else if (component is Ecs.Game.Components.PickupItemComponent PickupItem)
		{
			CopyPickupItemTo(PickupItem);
		}
		else if (component is Ecs.Game.Components.LookDirectionComponent LookDirection)
		{
			CopyLookDirectionTo(LookDirection);
		}
		else if (component is Ecs.Game.Components.PositionComponent Position)
		{
			CopyPositionTo(Position);
		}
		else if (component is Ecs.Game.Components.UidComponent Uid)
		{
			CopyUidTo(Uid);
		}
		else if (component is Ecs.Game.Components.OwnerComponent Owner)
		{
			CopyOwnerTo(Owner);
		}
		else if (component is Ecs.Game.Components.VelocityComponent Velocity)
		{
			CopyVelocityTo(Velocity);
		}
		else if (component is Ecs.Game.Components.CameraComponent Camera)
		{
			IsCamera = true;
		}
		else if (component is Ecs.Game.Components.PlayerComponent Player)
		{
			IsPlayer = true;
		}
		else if (component is Ecs.Game.Components.PlayerParametersComponent PlayerParameters)
		{
			CopyPlayerParametersTo(PlayerParameters);
		}
		else if (component is Ecs.Game.Components.HealthComponent Health)
		{
			CopyHealthTo(Health);
		}
		else if (component is Ecs.Game.Components.TotalScoreComponent TotalScore)
		{
			CopyTotalScoreTo(TotalScore);
		}
		else if (component is Ecs.Game.Components.DeadComponent Dead)
		{
			IsDead = true;
		}
		else if (component is Ecs.Game.Components.ActiveBulletTypeComponent ActiveBulletType)
		{
			CopyActiveBulletTypeTo(ActiveBulletType);
		}
		else if (component is Ecs.Game.Components.EnemyParametersComponent EnemyParameters)
		{
			CopyEnemyParametersTo(EnemyParameters);
		}
		else if (component is Ecs.Game.Components.TransformComponent Transform)
		{
			CopyTransformTo(Transform);
		}
		else if (component is Ecs.Game.Components.PrefabComponent Prefab)
		{
			CopyPrefabTo(Prefab);
		}
		else if (component is Ecs.Game.Components.BulletComponent Bullet)
		{
			CopyBulletTo(Bullet);
		}
		else if (component is Ecs.Game.Components.LocalPositionComponent LocalPosition)
		{
			CopyLocalPositionTo(LocalPosition);
		}
		else if (component is Ecs.Game.Components.LinkComponent Link)
		{
			CopyLinkTo(Link);
		}
		else if (component is Ecs.Game.Components.RotationComponent Rotation)
		{
			CopyRotationTo(Rotation);
		}
		else if (component is Ecs.Game.Components.CountComponent Count)
		{
			CopyCountTo(Count);
		}
		else if (component is Ecs.Game.Components.EnemyComponent Enemy)
		{
			CopyEnemyTo(Enemy);
		}
		else if (component is Ecs.Game.Components.InstantiateComponent Instantiate)
		{
			IsInstantiate = true;
		}
		else if (component is Ecs.Game.Components.LookPointComponent LookPoint)
		{
			CopyLookPointTo(LookPoint);
		}
		else if (component is Ecs.Game.Components.ScoreIndicatorComponent ScoreIndicator)
		{
			CopyScoreIndicatorTo(ScoreIndicator);
		}
		else if (component is GameDestroyedAddedListenerComponent GameDestroyedAddedListener)
		{
			CopyGameDestroyedAddedListenerTo(GameDestroyedAddedListener);
		}
		else if (component is ObjectTypeAddedListenerComponent ObjectTypeAddedListener)
		{
			CopyObjectTypeAddedListenerTo(ObjectTypeAddedListener);
		}
		else if (component is PositionAddedListenerComponent PositionAddedListener)
		{
			CopyPositionAddedListenerTo(PositionAddedListener);
		}
		else if (component is VelocityAddedListenerComponent VelocityAddedListener)
		{
			CopyVelocityAddedListenerTo(VelocityAddedListener);
		}
		else if (component is HealthAddedListenerComponent HealthAddedListener)
		{
			CopyHealthAddedListenerTo(HealthAddedListener);
		}
		else if (component is HealthRemovedListenerComponent HealthRemovedListener)
		{
			CopyHealthRemovedListenerTo(HealthRemovedListener);
		}
		else if (component is AnyTotalScoreAddedListenerComponent AnyTotalScoreAddedListener)
		{
			CopyAnyTotalScoreAddedListenerTo(AnyTotalScoreAddedListener);
		}
		else if (component is DeadAddedListenerComponent DeadAddedListener)
		{
			CopyDeadAddedListenerTo(DeadAddedListener);
		}
		else if (component is DeadRemovedListenerComponent DeadRemovedListener)
		{
			CopyDeadRemovedListenerTo(DeadRemovedListener);
		}
		else if (component is AnyActiveBulletTypeAddedListenerComponent AnyActiveBulletTypeAddedListener)
		{
			CopyAnyActiveBulletTypeAddedListenerTo(AnyActiveBulletTypeAddedListener);
		}
		else if (component is LocalPositionAddedListenerComponent LocalPositionAddedListener)
		{
			CopyLocalPositionAddedListenerTo(LocalPositionAddedListener);
		}
		else if (component is LinkRemovedListenerComponent LinkRemovedListener)
		{
			CopyLinkRemovedListenerTo(LinkRemovedListener);
		}
		else if (component is RotationAddedListenerComponent RotationAddedListener)
		{
			CopyRotationAddedListenerTo(RotationAddedListener);
		}
		else if (component is CountAddedListenerComponent CountAddedListener)
		{
			CopyCountAddedListenerTo(CountAddedListener);
		}
		else if (component is CountRemovedListenerComponent CountRemovedListener)
		{
			CopyCountRemovedListenerTo(CountRemovedListener);
		}
		else if (component is ScoreIndicatorAddedListenerComponent ScoreIndicatorAddedListener)
		{
			CopyScoreIndicatorAddedListenerTo(ScoreIndicatorAddedListener);
		}
		#endif
	}

	/// <summary>
	/// Copies all components on this entity to <paramref name="copyToEntity"/>.
	/// </summary>
	public void CopyTo(GameEntity copyToEntity)
	{
		for (var i = 0; i < GameComponentsLookup.TotalComponents; ++i)
		{
			if (HasComponent(i))
			{
				if (copyToEntity.HasComponent(i))
				{
					throw new EntityAlreadyHasComponentException(
						i,
						"Cannot copy component '" +
						GameComponentsLookup.ComponentNames[i] +
						"' to " +
						this +
						"!",
						"If replacement is intended, please call CopyTo() with `replaceExisting` set to true.");
				}

				var component = GetComponent(i);
				copyToEntity.CopyComponentTo(component);
			}
		}
	}

	/// <summary>
	/// Copies all components on this entity to <paramref name="copyToEntity"/>; if <paramref name="replaceExisting"/>
	/// is true any of the components that <paramref name="copyToEntity"/> has that this entity has will be replaced,
	/// otherwise they will be skipped.
	/// </summary>
	public void CopyTo(GameEntity copyToEntity, bool replaceExisting)
	{
		for (var i = 0; i < GameComponentsLookup.TotalComponents; ++i)
		{
			if (!HasComponent(i))
			{
				continue;
			}

			if (!copyToEntity.HasComponent(i) || replaceExisting)
			{
				var component = GetComponent(i);
				copyToEntity.CopyComponentTo(component);
			}
		}
	}

	/// <summary>
	/// Copies components on this entity at <paramref name="indices"/> in the <see cref="GameComponentsLookup"/> to
	/// <paramref name="copyToEntity"/>. If <paramref name="replaceExisting"/> is true any of the components that
	/// <paramref name="copyToEntity"/> has that this entity has will be replaced, otherwise they will be skipped.
	/// </summary>
	public void CopyTo(GameEntity copyToEntity, bool replaceExisting, params int[] indices)
	{
		for (var i = 0; i < indices.Length; ++i)
		{
			var index = indices[i];

			// Validate that the index is within range of the component lookup
			if (index < 0 && index >= GameComponentsLookup.TotalComponents)
			{
				const string OUT_OF_RANGE_WARNING =
					"Component Index [{0}] is out of range for [{1}].";

				const string HINT = "Please ensure any CopyTo indices are valid.";

				throw new IndexOutOfLookupRangeException(
					string.Format(OUT_OF_RANGE_WARNING, index, nameof(GameComponentsLookup)),
					HINT);
			}

			if (!HasComponent(index))
			{
				continue;
			}

			if (!copyToEntity.HasComponent(index) || replaceExisting)
			{
				var component = GetComponent(index);
				copyToEntity.CopyComponentTo(component);
			}
		}
	}
}
