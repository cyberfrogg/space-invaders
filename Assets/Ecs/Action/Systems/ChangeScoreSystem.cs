using System.Collections.Generic;
using Ecs.Core.Systems;
using Ecs.Utils;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using JCMG.EntitasRedux;

namespace Ecs.Action.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 300, nameof(EFeatures.Common))]
    public class ChangeScoreSystem : AReactiveSystemWithPool<ActionEntity>
    {
        private readonly GameContext _game;

        public ChangeScoreSystem(
            ActionContext action,
            GameContext game
            ) : base(action)
        {
            _game = game;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context)
            => context.CreateCollector(ActionMatcher.ChangeScore);

        protected override bool Filter(ActionEntity entity)
            => entity.HasChangeScore && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> actions)
        {
            foreach (var action in actions)
            {
                action.IsDestroyed = true;

                var score = _game.TotalScore.Value;
                score += action.ChangeScore.Value;
                _game.ReplaceTotalScore(score);
            }    
        }
    }
}