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
	public Ecs.Action.Components.ChangeScoreComponent ChangeScore { get { return (Ecs.Action.Components.ChangeScoreComponent)GetComponent(ActionComponentsLookup.ChangeScore); } }
	public bool HasChangeScore { get { return HasComponent(ActionComponentsLookup.ChangeScore); } }

	public void AddChangeScore(int newValue)
	{
		var index = ActionComponentsLookup.ChangeScore;
		var component = (Ecs.Action.Components.ChangeScoreComponent)CreateComponent(index, typeof(Ecs.Action.Components.ChangeScoreComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceChangeScore(int newValue)
	{
		var index = ActionComponentsLookup.ChangeScore;
		var component = (Ecs.Action.Components.ChangeScoreComponent)CreateComponent(index, typeof(Ecs.Action.Components.ChangeScoreComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyChangeScoreTo(Ecs.Action.Components.ChangeScoreComponent copyComponent)
	{
		var index = ActionComponentsLookup.ChangeScore;
		var component = (Ecs.Action.Components.ChangeScoreComponent)CreateComponent(index, typeof(Ecs.Action.Components.ChangeScoreComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = copyComponent.Value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveChangeScore()
	{
		RemoveComponent(ActionComponentsLookup.ChangeScore);
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
public partial class ActionEntity : IChangeScoreEntity { }

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
	static JCMG.EntitasRedux.IMatcher<ActionEntity> _matcherChangeScore;

	public static JCMG.EntitasRedux.IMatcher<ActionEntity> ChangeScore
	{
		get
		{
			if (_matcherChangeScore == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<ActionEntity>)JCMG.EntitasRedux.Matcher<ActionEntity>.AllOf(ActionComponentsLookup.ChangeScore);
				matcher.ComponentNames = ActionComponentsLookup.ComponentNames;
				_matcherChangeScore = matcher;
			}

			return _matcherChangeScore;
		}
	}
}
