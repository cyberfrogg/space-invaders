//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface ICountEntity
{
	Ecs.Game.Components.CountComponent Count { get; }
	bool HasCount { get; }

	void AddCount(int newValue);
	void ReplaceCount(int newValue);
	void RemoveCount();
}
