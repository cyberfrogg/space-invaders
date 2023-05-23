using System.Collections.Generic;
using Ecs.Core.Systems;
using Ecs.Game.Extensions;
using Ecs.Utils;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Game.Systems.Enemy
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 300, nameof(EFeatures.Enemy))]
    public class EnemyDeathSystem : AReactiveSystemWithPool<GameEntity>
    {
        private readonly GameContext _game;
        private readonly ActionContext _action;

        public EnemyDeathSystem(
            GameContext game,
            ActionContext action
            ) : base(game)
        {
            _game = game;
            _action = action;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
            => context.CreateCollector(GameMatcher.Health);

        protected override bool Filter(GameEntity entity)
            => entity.HasEnemy && entity.HasHealth && !entity.IsDead && !entity.IsDestroyed;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var enemy in entities)
            {
                if (enemy.Health.Value <= 0)
                {
                    enemy.IsDead = true;

                    _action.CreateEntity().AddChangeScore(enemy.EnemyParameters.Value.ScoreForKill);
                    _game.CreateScoreIndicator(enemy.EnemyParameters.Value.ScoreForKill, enemy.Position.Value + (Vector3.up * 2));
                }
            }
        }
    }
}