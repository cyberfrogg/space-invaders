//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IDeadRemovedListenerEntity
{
	DeadRemovedListenerComponent DeadRemovedListener { get; }
	bool HasDeadRemovedListener { get; }

	void AddDeadRemovedListener(System.Collections.Generic.List<IDeadRemovedListener> newValue);
	void ReplaceDeadRemovedListener(System.Collections.Generic.List<IDeadRemovedListener> newValue);
	void RemoveDeadRemovedListener();
}
