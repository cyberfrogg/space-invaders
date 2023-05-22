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
	public CountRemovedListenerComponent CountRemovedListener { get { return (CountRemovedListenerComponent)GetComponent(GameComponentsLookup.CountRemovedListener); } }
	public bool HasCountRemovedListener { get { return HasComponent(GameComponentsLookup.CountRemovedListener); } }

	public void AddCountRemovedListener(System.Collections.Generic.List<ICountRemovedListener> newValue)
	{
		var index = GameComponentsLookup.CountRemovedListener;
		var component = (CountRemovedListenerComponent)CreateComponent(index, typeof(CountRemovedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceCountRemovedListener(System.Collections.Generic.List<ICountRemovedListener> newValue)
	{
		var index = GameComponentsLookup.CountRemovedListener;
		var component = (CountRemovedListenerComponent)CreateComponent(index, typeof(CountRemovedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyCountRemovedListenerTo(CountRemovedListenerComponent copyComponent)
	{
		var index = GameComponentsLookup.CountRemovedListener;
		var component = (CountRemovedListenerComponent)CreateComponent(index, typeof(CountRemovedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = copyComponent.value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveCountRemovedListener()
	{
		RemoveComponent(GameComponentsLookup.CountRemovedListener);
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
public partial class GameEntity : ICountRemovedListenerEntity { }

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherCountRemovedListener;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> CountRemovedListener
	{
		get
		{
			if (_matcherCountRemovedListener == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.CountRemovedListener);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherCountRemovedListener = matcher;
			}

			return _matcherCountRemovedListener;
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
	public void AddCountRemovedListener(ICountRemovedListener value)
	{
		var listeners = HasCountRemovedListener
			? CountRemovedListener.value
			: new System.Collections.Generic.List<ICountRemovedListener>();
		listeners.Add(value);
		ReplaceCountRemovedListener(listeners);
	}

	public void RemoveCountRemovedListener(ICountRemovedListener value, bool removeComponentWhenEmpty = true)
	{
		var listeners = CountRemovedListener.value;
		listeners.Remove(value);
		if (removeComponentWhenEmpty && listeners.Count == 0)
		{
			RemoveCountRemovedListener();
		}
		else
		{
			ReplaceCountRemovedListener(listeners);
		}
	}
}
