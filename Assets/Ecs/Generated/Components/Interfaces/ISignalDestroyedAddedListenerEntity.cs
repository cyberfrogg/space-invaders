//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface ISignalDestroyedAddedListenerEntity
{
	SignalDestroyedAddedListenerComponent SignalDestroyedAddedListener { get; }
	bool HasSignalDestroyedAddedListener { get; }

	void AddSignalDestroyedAddedListener(System.Collections.Generic.List<ISignalDestroyedAddedListener> newValue);
	void ReplaceSignalDestroyedAddedListener(System.Collections.Generic.List<ISignalDestroyedAddedListener> newValue);
	void RemoveSignalDestroyedAddedListener();
}
