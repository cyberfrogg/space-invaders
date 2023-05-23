//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity
{
	public Ecs.Game.Components.PickupItemComponent PickupItem { get { return (Ecs.Game.Components.PickupItemComponent)GetComponent(GameComponentsLookup.PickupItem); } }
	public bool HasPickupItem { get { return HasComponent(GameComponentsLookup.PickupItem); } }

	public void AddPickupItem(Db.PickupItems.EPickupItemType newType)
	{
		var index = GameComponentsLookup.PickupItem;
		var component = (Ecs.Game.Components.PickupItemComponent)CreateComponent(index, typeof(Ecs.Game.Components.PickupItemComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Type = newType;
		#endif
		AddComponent(index, component);
	}

	public void ReplacePickupItem(Db.PickupItems.EPickupItemType newType)
	{
		var index = GameComponentsLookup.PickupItem;
		var component = (Ecs.Game.Components.PickupItemComponent)CreateComponent(index, typeof(Ecs.Game.Components.PickupItemComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Type = newType;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyPickupItemTo(Ecs.Game.Components.PickupItemComponent copyComponent)
	{
		var index = GameComponentsLookup.PickupItem;
		var component = (Ecs.Game.Components.PickupItemComponent)CreateComponent(index, typeof(Ecs.Game.Components.PickupItemComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Type = copyComponent.Type;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemovePickupItem()
	{
		RemoveComponent(GameComponentsLookup.PickupItem);
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
public partial class GameEntity : IPickupItemEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher
{
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherPickupItem;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> PickupItem
	{
		get
		{
			if (_matcherPickupItem == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.PickupItem);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherPickupItem = matcher;
			}

			return _matcherPickupItem;
		}
	}
}