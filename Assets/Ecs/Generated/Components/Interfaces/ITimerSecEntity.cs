//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface ITimerSecEntity
{
	Ecs.Scheduler.Components.TimerSecComponent TimerSec { get; }
	bool HasTimerSec { get; }

	void AddTimerSec(float newValue);
	void ReplaceTimerSec(float newValue);
	void RemoveTimerSec();
}
