using Ecs.Views.Linkable;
using Zenject;

namespace Game.Services.Pool
{
	public interface IPrefabMemoryPool : IMemoryPool<ILinkable>
	{
		string Name { get; }
	}
}