using Ecs.Game.Extensions;
using Ecs.Utils;
using Game.Providers;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using JCMG.EntitasRedux;
using Zenject;

namespace Ecs.Game.Systems.Initialize
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 30, nameof(EFeatures.Initialization))]
    public class PlayerInitializeSystem : IInitializeSystem
    {
        private readonly GameContext _game;
        private readonly DiContainer _diContainer;
        private readonly IGameFieldProvider _gameFieldProvider;
        private readonly ILinkedEntityRepository _linkedEntityRepository;

        public PlayerInitializeSystem(
            GameContext game,
            DiContainer diContainer,
            IGameFieldProvider gameFieldProvider,
            ILinkedEntityRepository linkedEntityRepository
        )
        {
            _game = game;
            _diContainer = diContainer;
            _gameFieldProvider = gameFieldProvider;
            _linkedEntityRepository = linkedEntityRepository;
        }

        public void Initialize()
        {
            var playerView = _gameFieldProvider.GameField.PlayerView;
            var playerTransform = playerView.transform;
            var player = _game.CreatePlayer(playerTransform.position, playerTransform.rotation);
            
            playerView.Link(player, _game);
            _linkedEntityRepository.Add(playerTransform.GetHashCode(), player);
            _diContainer.Inject(playerView);
        }
    }
}