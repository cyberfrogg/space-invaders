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
	public DeadRemovedListenerComponent DeadRemovedListener { get { return (DeadRemovedListenerComponent)GetComponent(GameComponentsLookup.DeadRemovedListener); } }
	public bool HasDeadRemovedListener { get { return HasComponent(GameComponentsLookup.DeadRemovedListener); } }

	public void AddDeadRemovedListener(System.Collections.Generic.List<IDeadRemovedListener> newValue)
	{
		var index = GameComponentsLookup.DeadRemovedListener;
		var component = (DeadRemovedListenerComponent)CreateComponent(index, typeof(DeadRemovedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceDeadRemovedListener(System.Collections.Generic.List<IDeadRemovedListener> newValue)
	{
		var index = GameComponentsLookup.DeadRemovedListener;
		var component = (DeadRemovedListenerComponent)CreateComponent(index, typeof(DeadRemovedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyDeadRemovedListenerTo(DeadRemovedListenerComponent copyComponent)
	{
		var index = GameComponentsLookup.DeadRemovedListener;
		var component = (DeadRemovedListenerComponent)CreateComponent(index, typeof(DeadRemovedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = copyComponent.value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveDeadRemovedListener()
	{
		RemoveComponent(GameComponentsLookup.DeadRemovedListener);
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
public partial class GameEntity : IDeadRemovedListenerEntity { }

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherDeadRemovedListener;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> DeadRemovedListener
	{
		get
		{
			if (_matcherDeadRemovedListener == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.DeadRemovedListener);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherDeadRemovedListener = matcher;
			}

			return _matcherDeadRemovedListener;
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
public partial class GameEntity
{
	public void AddDeadRemovedListener(IDeadRemovedListener value)
	{
		var listeners = HasDeadRemovedListener
			? DeadRemovedListener.value
			: new System.Collections.Generic.List<IDeadRemovedListener>();
		listeners.Add(value);
		ReplaceDeadRemovedListener(listeners);
	}

	public void RemoveDeadRemovedListener(IDeadRemovedListener value, bool removeComponentWhenEmpty = true)
	{
		var listeners = DeadRemovedListener.value;
		listeners.Remove(value);
		if (removeComponentWhenEmpty && listeners.Count == 0)
		{
			RemoveDeadRemovedListener();
		}
		else
		{
			ReplaceDeadRemovedListener(listeners);
		}
	}
}
