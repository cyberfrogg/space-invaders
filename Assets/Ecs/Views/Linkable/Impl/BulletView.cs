using UnityEngine;
using Zenject;

namespace Ecs.Views.Linkable.Impl
{
    public class BulletView : ObjectView
    {
        [Inject] private ActionContext _action;
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            _action.CreateEntity().AddCollideBullet(transform.GetHashCode(), collision.transform.GetHashCode());
        }
    }
}