using System.Collections.Generic;
using Ecs.Core.Interfaces;
using Ecs.Core.Systems;
using Ecs.Utils;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Action.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 900, nameof(EFeatures.Move))]
    public class MoveSystem : AReactiveSystemWithPool<ActionEntity>
    {
        private readonly GameContext _game;
        private readonly ITimeProvider _timeProvider;

        public MoveSystem(
            ActionContext action,
            GameContext game,
            ITimeProvider timeProvider
            ) : base(action)
        {
            _game = game;
            _timeProvider = timeProvider;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context)
            => context.CreateCollector(ActionMatcher.Move);

        protected override bool Filter(ActionEntity entity)
            => entity.HasMove && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> actions)
        {
            foreach (var action in actions)
            {
                action.IsDestroyed = true;

                var player = _game.PlayerEntity;
                var playerParameters = player.PlayerParameters.Value;
                var playerVelocity = action.Move.Direction * playerParameters.Speed;
                player.ReplaceVelocity(playerVelocity);
            }
        }
    }
}