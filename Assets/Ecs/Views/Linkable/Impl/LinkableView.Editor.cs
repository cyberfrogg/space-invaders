#if UNITY_EDITOR
using JCMG.EntitasRedux;
using UnityEditor;

namespace Ecs.Views.Linkable.Impl
{
	public abstract partial class LinkableView
	{
		public void EditorCacheEntityLink()
		{
			if (entityLink != null)
				return;

			var so = new SerializedObject(this);
			var entityLinkSp = so.FindProperty(nameof(entityLink));
			entityLinkSp.objectReferenceValue = GetComponent<EntityLink>();
		}

		private void OnValidate()
		{
			EditorCacheEntityLink();
		}
	}
}
#endif