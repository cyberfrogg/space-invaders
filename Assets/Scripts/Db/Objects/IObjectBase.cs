using UnityEngine;

namespace Db.Objects
{
	public interface IObjectBase
	{
		ObjectData[] Objects { get; }
		bool Contains(EObjectType type);
		GameObject Get(EObjectType type);
	}
}