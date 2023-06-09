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
	public Ecs.Common.Components.ObjectTypeComponent ObjectType { get { return (Ecs.Common.Components.ObjectTypeComponent)GetComponent(GameComponentsLookup.ObjectType); } }
	public bool HasObjectType { get { return HasComponent(GameComponentsLookup.ObjectType); } }

	public void AddObjectType(Db.EObjectType newValue)
	{
		var index = GameComponentsLookup.ObjectType;
		var component = (Ecs.Common.Components.ObjectTypeComponent)CreateComponent(index, typeof(Ecs.Common.Components.ObjectTypeComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceObjectType(Db.EObjectType newValue)
	{
		var index = GameComponentsLookup.ObjectType;
		var component = (Ecs.Common.Components.ObjectTypeComponent)CreateComponent(index, typeof(Ecs.Common.Components.ObjectTypeComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyObjectTypeTo(Ecs.Common.Components.ObjectTypeComponent copyComponent)
	{
		var index = GameComponentsLookup.ObjectType;
		var component = (Ecs.Common.Components.ObjectTypeComponent)CreateComponent(index, typeof(Ecs.Common.Components.ObjectTypeComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = copyComponent.Value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveObjectType()
	{
		RemoveComponent(GameComponentsLookup.ObjectType);
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
public partial class GameEntity : IObjectTypeEntity { }

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherObjectType;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> ObjectType
	{
		get
		{
			if (_matcherObjectType == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.ObjectType);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherObjectType = matcher;
			}

			return _matcherObjectType;
		}
	}
}
