using Ecs.Scheduler.Extensions;
using JCMG.EntitasRedux;
using TMPro;
using UnityEngine;
using Zenject;

namespace Ecs.Views.Linkable.Impl
{
    public class ScoreIndicatorView : ObjectView
    {
        [SerializeField] private TextMeshPro _text;
        [SerializeField] private float _destroyDelay;

        [Inject] private SchedulerContext _scheduler;
        
        public override void Link(IEntity entity, IContext context)
        {
            var e = (GameEntity)entity;

            SetScore(e.ScoreIndicator.Score);

            _scheduler.CreateTimerAction(() =>
            {
                e.IsDestroyed = true;
            }, _destroyDelay);
            
            base.Link(entity, context);
        }

        private void SetScore(int score)
        {
            _text.text = $"+{score}";
        }
    }
}