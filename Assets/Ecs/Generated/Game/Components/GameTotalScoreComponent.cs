//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

	public GameEntity TotalScoreEntity { get { return GetGroup(GameMatcher.TotalScore).GetSingleEntity(); } }
	public Ecs.Game.Components.TotalScoreComponent TotalScore { get { return TotalScoreEntity.TotalScore; } }
	public bool HasTotalScore { get { return TotalScoreEntity != null; } }

	public GameEntity SetTotalScore(int newValue)
	{
		if (HasTotalScore)
		{
			throw new JCMG.EntitasRedux.EntitasReduxException(
				"Could not set TotalScore!\n" +
				this +
				" already has an entity with Ecs.Game.Components.TotalScoreComponent!",
				"You should check if the context already has a TotalScoreEntity before setting it or use context.ReplaceTotalScore().");
		}
		var entity = CreateEntity();
		#if !ENTITAS_REDUX_NO_IMPL
		entity.AddTotalScore(newValue);
		#endif
		return entity;
	}

	public void ReplaceTotalScore(int newValue)
	{
		#if !ENTITAS_REDUX_NO_IMPL
		var entity = TotalScoreEntity;
		if (entity == null)
		{
			entity = SetTotalScore(newValue);
		}
		else
		{
			entity.ReplaceTotalScore(newValue);
		}
		#endif
	}

	public void RemoveTotalScore()
	{
		TotalScoreEntity.Destroy();
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
public partial class GameEntity
{
	public Ecs.Game.Components.TotalScoreComponent TotalScore { get { return (Ecs.Game.Components.TotalScoreComponent)GetComponent(GameComponentsLookup.TotalScore); } }
	public bool HasTotalScore { get { return HasComponent(GameComponentsLookup.TotalScore); } }

	public void AddTotalScore(int newValue)
	{
		var index = GameComponentsLookup.TotalScore;
		var component = (Ecs.Game.Components.TotalScoreComponent)CreateComponent(index, typeof(Ecs.Game.Components.TotalScoreComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceTotalScore(int newValue)
	{
		var index = GameComponentsLookup.TotalScore;
		var component = (Ecs.Game.Components.TotalScoreComponent)CreateComponent(index, typeof(Ecs.Game.Components.TotalScoreComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyTotalScoreTo(Ecs.Game.Components.TotalScoreComponent copyComponent)
	{
		var index = GameComponentsLookup.TotalScore;
		var component = (Ecs.Game.Components.TotalScoreComponent)CreateComponent(index, typeof(Ecs.Game.Components.TotalScoreComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = copyComponent.Value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveTotalScore()
	{
		RemoveComponent(GameComponentsLookup.TotalScore);
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
public partial class GameEntity : ITotalScoreEntity { }

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherTotalScore;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> TotalScore
	{
		get
		{
			if (_matcherTotalScore == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.TotalScore);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherTotalScore = matcher;
			}

			return _matcherTotalScore;
		}
	}
}
