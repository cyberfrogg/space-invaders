using UnityEngine;
using Utils.Drawers.Key;

namespace Db.Objects.Impl
{
	[CreateAssetMenu(menuName = "Settings/" + nameof(ObjectBase), fileName = nameof(ObjectBase))]
	public class ObjectBase : ScriptableObject, IObjectBase
	{
		[KeyValue("type")] [SerializeField] private ObjectData[] objects;

		public ObjectData[] Objects => objects;

		public bool Contains(EObjectType type)
		{
			foreach (var objectData in Objects)
			{
				if (objectData.type == type)
					return true;
			}
			return false;
		}
		
		public GameObject Get(EObjectType type)
		{
			foreach (var objectData in objects)
			{
				if (objectData.type == type)
				{
					var length = objectData.prefabs.Length;
					var randomIndex = Random.Range(0, length);
					return objectData.prefabs[randomIndex];
				}
			}

			throw new System.Exception($"[ObjectBase] No object in base: {type}");
		}
	}
}