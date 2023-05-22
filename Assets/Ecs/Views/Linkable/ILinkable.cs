using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Views.Linkable
{
	public interface ILinkable : IObjectHash
	{
		Transform Transform { get; }

		void Link(IEntity entity, IContext context);
	}
}