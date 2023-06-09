//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class AnyTotalScoreAddedEventSystem : JCMG.EntitasRedux.ReactiveSystem<GameEntity>
{
	readonly JCMG.EntitasRedux.IGroup<GameEntity> _listeners;
	readonly System.Collections.Generic.List<GameEntity> _entityBuffer;
	readonly System.Collections.Generic.List<IAnyTotalScoreAddedListener> _listenerBuffer;

	public AnyTotalScoreAddedEventSystem(Contexts contexts) : base(contexts.Game)
	{
		_listeners = contexts.Game.GetGroup(GameMatcher.AnyTotalScoreAddedListener);
		_entityBuffer = new System.Collections.Generic.List<GameEntity>();
		_listenerBuffer = new System.Collections.Generic.List<IAnyTotalScoreAddedListener>();
	}

	protected override JCMG.EntitasRedux.ICollector<GameEntity> GetTrigger(JCMG.EntitasRedux.IContext<GameEntity> context)
	{
		return JCMG.EntitasRedux.CollectorContextExtension.CreateCollector(
			context,
			JCMG.EntitasRedux.TriggerOnEventMatcherExtension.Added(GameMatcher.TotalScore)
		);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.HasTotalScore;
	}

	protected override void Execute(System.Collections.Generic.List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			var component = e.TotalScore;
			foreach (var listenerEntity in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(listenerEntity.AnyTotalScoreAddedListener.value);
				foreach (var listener in _listenerBuffer)
				{
					listener.OnAnyTotalScoreAdded(e, component.Value);
				}
			}
		}
	}
}
