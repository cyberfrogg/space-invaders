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
	public ObjectTypeAddedListenerComponent ObjectTypeAddedListener { get { return (ObjectTypeAddedListenerComponent)GetComponent(GameComponentsLookup.ObjectTypeAddedListener); } }
	public bool HasObjectTypeAddedListener { get { return HasComponent(GameComponentsLookup.ObjectTypeAddedListener); } }

	public void AddObjectTypeAddedListener(System.Collections.Generic.List<IObjectTypeAddedListener> newValue)
	{
		var index = GameComponentsLookup.ObjectTypeAddedListener;
		var component = (ObjectTypeAddedListenerComponent)CreateComponent(index, typeof(ObjectTypeAddedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceObjectTypeAddedListener(System.Collections.Generic.List<IObjectTypeAddedListener> newValue)
	{
		var index = GameComponentsLookup.ObjectTypeAddedListener;
		var component = (ObjectTypeAddedListenerComponent)CreateComponent(index, typeof(ObjectTypeAddedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyObjectTypeAddedListenerTo(ObjectTypeAddedListenerComponent copyComponent)
	{
		var index = GameComponentsLookup.ObjectTypeAddedListener;
		var component = (ObjectTypeAddedListenerComponent)CreateComponent(index, typeof(ObjectTypeAddedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = copyComponent.value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveObjectTypeAddedListener()
	{
		RemoveComponent(GameComponentsLookup.ObjectTypeAddedListener);
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
public partial class GameEntity : IObjectTypeAddedListenerEntity { }

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherObjectTypeAddedListener;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> ObjectTypeAddedListener
	{
		get
		{
			if (_matcherObjectTypeAddedListener == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.ObjectTypeAddedListener);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherObjectTypeAddedListener = matcher;
			}

			return _matcherObjectTypeAddedListener;
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
	public void AddObjectTypeAddedListener(IObjectTypeAddedListener value)
	{
		var listeners = HasObjectTypeAddedListener
			? ObjectTypeAddedListener.value
			: new System.Collections.Generic.List<IObjectTypeAddedListener>();
		listeners.Add(value);
		ReplaceObjectTypeAddedListener(listeners);
	}

	public void RemoveObjectTypeAddedListener(IObjectTypeAddedListener value, bool removeComponentWhenEmpty = true)
	{
		var listeners = ObjectTypeAddedListener.value;
		listeners.Remove(value);
		if (removeComponentWhenEmpty && listeners.Count == 0)
		{
			RemoveObjectTypeAddedListener();
		}
		else
		{
			ReplaceObjectTypeAddedListener(listeners);
		}
	}
}
