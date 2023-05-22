//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ActionEntity
{
	public Ecs.Action.Components.Shoot.ShootComponent Shoot { get { return (Ecs.Action.Components.Shoot.ShootComponent)GetComponent(ActionComponentsLookup.Shoot); } }
	public bool HasShoot { get { return HasComponent(ActionComponentsLookup.Shoot); } }

	public void AddShoot(Ecs.Managers.Uid newOwner)
	{
		var index = ActionComponentsLookup.Shoot;
		var component = (Ecs.Action.Components.Shoot.ShootComponent)CreateComponent(index, typeof(Ecs.Action.Components.Shoot.ShootComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Owner = newOwner;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceShoot(Ecs.Managers.Uid newOwner)
	{
		var index = ActionComponentsLookup.Shoot;
		var component = (Ecs.Action.Components.Shoot.ShootComponent)CreateComponent(index, typeof(Ecs.Action.Components.Shoot.ShootComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Owner = newOwner;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyShootTo(Ecs.Action.Components.Shoot.ShootComponent copyComponent)
	{
		var index = ActionComponentsLookup.Shoot;
		var component = (Ecs.Action.Components.Shoot.ShootComponent)CreateComponent(index, typeof(Ecs.Action.Components.Shoot.ShootComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Owner = copyComponent.Owner;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveShoot()
	{
		RemoveComponent(ActionComponentsLookup.Shoot);
	}
}

//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ActionEntity : IShootEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class ActionMatcher
{
	static JCMG.EntitasRedux.IMatcher<ActionEntity> _matcherShoot;

	public static JCMG.EntitasRedux.IMatcher<ActionEntity> Shoot
	{
		get
		{
			if (_matcherShoot == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<ActionEntity>)JCMG.EntitasRedux.Matcher<ActionEntity>.AllOf(ActionComponentsLookup.Shoot);
				matcher.ComponentNames = ActionComponentsLookup.ComponentNames;
				_matcherShoot = matcher;
			}

			return _matcherShoot;
		}
	}
}
