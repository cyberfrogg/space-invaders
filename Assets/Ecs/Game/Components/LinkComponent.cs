using Ecs.Views.Linkable;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
	[Game]
	[Event(EventTarget.Self, EventType.Removed)]
	public class LinkComponent : IComponent
	{
		public ILinkable View;

		public override string ToString()
			=> "Link: " + ((View != null && View.Transform != null) ? View.Transform.name : "Null");
	}
}