//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IActiveBulletTypeEntity
{
	Ecs.Game.Components.ActiveBulletTypeComponent ActiveBulletType { get; }
	bool HasActiveBulletType { get; }

	void AddActiveBulletType(Db.Bullet.EBulletType newValue);
	void ReplaceActiveBulletType(Db.Bullet.EBulletType newValue);
	void RemoveActiveBulletType();
}