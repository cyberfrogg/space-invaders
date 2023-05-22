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
	public Ecs.Action.Components.MovePlayerComponent MovePlayer { get { return (Ecs.Action.Components.MovePlayerComponent)GetComponent(ActionComponentsLookup.MovePlayer); } }
	public bool HasMovePlayer { get { return HasComponent(ActionComponentsLookup.MovePlayer); } }

	public void AddMovePlayer(UnityEngine.Vector2 newDirection)
	{
		var index = ActionComponentsLookup.MovePlayer;
		var component = (Ecs.Action.Components.MovePlayerComponent)CreateComponent(index, typeof(Ecs.Action.Components.MovePlayerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Direction = newDirection;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceMovePlayer(UnityEngine.Vector2 newDirection)
	{
		var index = ActionComponentsLookup.MovePlayer;
		var component = (Ecs.Action.Components.MovePlayerComponent)CreateComponent(index, typeof(Ecs.Action.Components.MovePlayerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Direction = newDirection;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyMovePlayerTo(Ecs.Action.Components.MovePlayerComponent copyComponent)
	{
		var index = ActionComponentsLookup.MovePlayer;
		var component = (Ecs.Action.Components.MovePlayerComponent)CreateComponent(index, typeof(Ecs.Action.Components.MovePlayerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Direction = copyComponent.Direction;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveMovePlayer()
	{
		RemoveComponent(ActionComponentsLookup.MovePlayer);
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
public partial class ActionEntity : IMovePlayerEntity { }

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
	static JCMG.EntitasRedux.IMatcher<ActionEntity> _matcherMovePlayer;

	public static JCMG.EntitasRedux.IMatcher<ActionEntity> MovePlayer
	{
		get
		{
			if (_matcherMovePlayer == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<ActionEntity>)JCMG.EntitasRedux.Matcher<ActionEntity>.AllOf(ActionComponentsLookup.MovePlayer);
				matcher.ComponentNames = ActionComponentsLookup.ComponentNames;
				_matcherMovePlayer = matcher;
			}

			return _matcherMovePlayer;
		}
	}
}