//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class DeadRemovedEventSystem : JCMG.EntitasRedux.ReactiveSystem<GameEntity>
{
	readonly System.Collections.Generic.List<IDeadRemovedListener> _listenerBuffer;

	public DeadRemovedEventSystem(Contexts contexts) : base(contexts.Game)
	{
		_listenerBuffer = new System.Collections.Generic.List<IDeadRemovedListener>();
	}

	protected override JCMG.EntitasRedux.ICollector<GameEntity> GetTrigger(JCMG.EntitasRedux.IContext<GameEntity> context)
	{
		return JCMG.EntitasRedux.CollectorContextExtension.CreateCollector(
			context,
			JCMG.EntitasRedux.TriggerOnEventMatcherExtension.Removed(GameMatcher.Dead)
		);
	}

	protected override bool Filter(GameEntity entity)
	{
		return !entity.IsDead && entity.HasDeadRemovedListener;
	}

	protected override void Execute(System.Collections.Generic.List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(e.DeadRemovedListener.value);
			foreach (var listener in _listenerBuffer)
			{
				listener.OnDeadRemoved(e);
			}
		}
	}
}
