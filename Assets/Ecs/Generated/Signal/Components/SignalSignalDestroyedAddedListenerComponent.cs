//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class SignalEntity
{
	public SignalDestroyedAddedListenerComponent SignalDestroyedAddedListener { get { return (SignalDestroyedAddedListenerComponent)GetComponent(SignalComponentsLookup.SignalDestroyedAddedListener); } }
	public bool HasSignalDestroyedAddedListener { get { return HasComponent(SignalComponentsLookup.SignalDestroyedAddedListener); } }

	public void AddSignalDestroyedAddedListener(System.Collections.Generic.List<ISignalDestroyedAddedListener> newValue)
	{
		var index = SignalComponentsLookup.SignalDestroyedAddedListener;
		var component = (SignalDestroyedAddedListenerComponent)CreateComponent(index, typeof(SignalDestroyedAddedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceSignalDestroyedAddedListener(System.Collections.Generic.List<ISignalDestroyedAddedListener> newValue)
	{
		var index = SignalComponentsLookup.SignalDestroyedAddedListener;
		var component = (SignalDestroyedAddedListenerComponent)CreateComponent(index, typeof(SignalDestroyedAddedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopySignalDestroyedAddedListenerTo(SignalDestroyedAddedListenerComponent copyComponent)
	{
		var index = SignalComponentsLookup.SignalDestroyedAddedListener;
		var component = (SignalDestroyedAddedListenerComponent)CreateComponent(index, typeof(SignalDestroyedAddedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = copyComponent.value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveSignalDestroyedAddedListener()
	{
		RemoveComponent(SignalComponentsLookup.SignalDestroyedAddedListener);
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
public partial class SignalEntity : ISignalDestroyedAddedListenerEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class SignalMatcher
{
	static JCMG.EntitasRedux.IMatcher<SignalEntity> _matcherSignalDestroyedAddedListener;

	public static JCMG.EntitasRedux.IMatcher<SignalEntity> SignalDestroyedAddedListener
	{
		get
		{
			if (_matcherSignalDestroyedAddedListener == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<SignalEntity>)JCMG.EntitasRedux.Matcher<SignalEntity>.AllOf(SignalComponentsLookup.SignalDestroyedAddedListener);
				matcher.ComponentNames = SignalComponentsLookup.ComponentNames;
				_matcherSignalDestroyedAddedListener = matcher;
			}

			return _matcherSignalDestroyedAddedListener;
		}
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
public partial class SignalEntity
{
	public void AddSignalDestroyedAddedListener(ISignalDestroyedAddedListener value)
	{
		var listeners = HasSignalDestroyedAddedListener
			? SignalDestroyedAddedListener.value
			: new System.Collections.Generic.List<ISignalDestroyedAddedListener>();
		listeners.Add(value);
		ReplaceSignalDestroyedAddedListener(listeners);
	}

	public void RemoveSignalDestroyedAddedListener(ISignalDestroyedAddedListener value, bool removeComponentWhenEmpty = true)
	{
		var listeners = SignalDestroyedAddedListener.value;
		listeners.Remove(value);
		if (removeComponentWhenEmpty && listeners.Count == 0)
		{
			RemoveSignalDestroyedAddedListener();
		}
		else
		{
			ReplaceSignalDestroyedAddedListener(listeners);
		}
	}
}
