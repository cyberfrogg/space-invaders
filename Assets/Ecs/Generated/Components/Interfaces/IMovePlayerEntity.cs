//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IMovePlayerEntity
{
	Ecs.Action.Components.MovePlayerComponent MovePlayer { get; }
	bool HasMovePlayer { get; }

	void AddMovePlayer(UnityEngine.Vector2 newDirection);
	void ReplaceMovePlayer(UnityEngine.Vector2 newDirection);
	void RemoveMovePlayer();
}
