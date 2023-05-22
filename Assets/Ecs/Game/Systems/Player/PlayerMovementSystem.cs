using Ecs.Core.Interfaces;
using Ecs.Utils;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using JCMG.EntitasRedux;

namespace Ecs.Game.Systems.Player
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 300, nameof(EFeatures.Move))]
    public class PlayerMovementSystem : IUpdateSystem
    {
        private readonly GameContext _game;
        private readonly ITimeProvider _timeProvider;

        public PlayerMovementSystem(
            GameContext game,
            ITimeProvider timeProvider
            )
        {
            _game = game;
            _timeProvider = timeProvider;
        }

        public void Update()
        {
            var player = _game.PlayerEntity;

            var playerPos = player.Position.Value;
            playerPos += player.Velocity.Value * _timeProvider.DeltaTime;
            player.ReplacePosition(playerPos);
        }
    }
}