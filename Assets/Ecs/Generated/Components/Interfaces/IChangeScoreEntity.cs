//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IChangeScoreEntity
{
	Ecs.Action.Components.ChangeScoreComponent ChangeScore { get; }
	bool HasChangeScore { get; }

	void AddChangeScore(int newValue);
	void ReplaceChangeScore(int newValue);
	void RemoveChangeScore();
}
