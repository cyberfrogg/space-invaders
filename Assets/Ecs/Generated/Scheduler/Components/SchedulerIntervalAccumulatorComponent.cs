//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class SchedulerEntity
{
	public Ecs.Scheduler.Components.IntervalAccumulatorComponent IntervalAccumulator { get { return (Ecs.Scheduler.Components.IntervalAccumulatorComponent)GetComponent(SchedulerComponentsLookup.IntervalAccumulator); } }
	public bool HasIntervalAccumulator { get { return HasComponent(SchedulerComponentsLookup.IntervalAccumulator); } }

	public void AddIntervalAccumulator(float newValue)
	{
		var index = SchedulerComponentsLookup.IntervalAccumulator;
		var component = (Ecs.Scheduler.Components.IntervalAccumulatorComponent)CreateComponent(index, typeof(Ecs.Scheduler.Components.IntervalAccumulatorComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceIntervalAccumulator(float newValue)
	{
		var index = SchedulerComponentsLookup.IntervalAccumulator;
		var component = (Ecs.Scheduler.Components.IntervalAccumulatorComponent)CreateComponent(index, typeof(Ecs.Scheduler.Components.IntervalAccumulatorComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyIntervalAccumulatorTo(Ecs.Scheduler.Components.IntervalAccumulatorComponent copyComponent)
	{
		var index = SchedulerComponentsLookup.IntervalAccumulator;
		var component = (Ecs.Scheduler.Components.IntervalAccumulatorComponent)CreateComponent(index, typeof(Ecs.Scheduler.Components.IntervalAccumulatorComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = copyComponent.Value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveIntervalAccumulator()
	{
		RemoveComponent(SchedulerComponentsLookup.IntervalAccumulator);
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
public partial class SchedulerEntity : IIntervalAccumulatorEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class SchedulerMatcher
{
	static JCMG.EntitasRedux.IMatcher<SchedulerEntity> _matcherIntervalAccumulator;

	public static JCMG.EntitasRedux.IMatcher<SchedulerEntity> IntervalAccumulator
	{
		get
		{
			if (_matcherIntervalAccumulator == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<SchedulerEntity>)JCMG.EntitasRedux.Matcher<SchedulerEntity>.AllOf(SchedulerComponentsLookup.IntervalAccumulator);
				matcher.ComponentNames = SchedulerComponentsLookup.ComponentNames;
				_matcherIntervalAccumulator = matcher;
			}

			return _matcherIntervalAccumulator;
		}
	}
}
