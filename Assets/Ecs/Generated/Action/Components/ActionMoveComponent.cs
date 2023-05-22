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
	public Ecs.Action.Components.MoveComponent Move { get { return (Ecs.Action.Components.MoveComponent)GetComponent(ActionComponentsLookup.Move); } }
	public bool HasMove { get { return HasComponent(ActionComponentsLookup.Move); } }

	public void AddMove(UnityEngine.Vector2 newDirection)
	{
		var index = ActionComponentsLookup.Move;
		var component = (Ecs.Action.Components.MoveComponent)CreateComponent(index, typeof(Ecs.Action.Components.MoveComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Direction = newDirection;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceMove(UnityEngine.Vector2 newDirection)
	{
		var index = ActionComponentsLookup.Move;
		var component = (Ecs.Action.Components.MoveComponent)CreateComponent(index, typeof(Ecs.Action.Components.MoveComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Direction = newDirection;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyMoveTo(Ecs.Action.Components.MoveComponent copyComponent)
	{
		var index = ActionComponentsLookup.Move;
		var component = (Ecs.Action.Components.MoveComponent)CreateComponent(index, typeof(Ecs.Action.Components.MoveComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Direction = copyComponent.Direction;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveMove()
	{
		RemoveComponent(ActionComponentsLookup.Move);
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
public partial class ActionEntity : IMoveEntity { }

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
	static JCMG.EntitasRedux.IMatcher<ActionEntity> _matcherMove;

	public static JCMG.EntitasRedux.IMatcher<ActionEntity> Move
	{
		get
		{
			if (_matcherMove == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<ActionEntity>)JCMG.EntitasRedux.Matcher<ActionEntity>.AllOf(ActionComponentsLookup.Move);
				matcher.ComponentNames = ActionComponentsLookup.ComponentNames;
				_matcherMove = matcher;
			}

			return _matcherMove;
		}
	}
}
