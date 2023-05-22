using JCMG.EntitasRedux;
using SimpleUi.Interfaces;

namespace Ecs.Views.Linkable
{
    public interface ILinkableUi<in TEntity> : IUiView, ILinkable
        where TEntity : IEntity
    {
        void Unlink();
        void Listen(TEntity entity);
        void Unlisten(TEntity entity);
        void Reset();
    }
}