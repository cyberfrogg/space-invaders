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
    public class EnemyInitializeSystem : IInitializeSystem
    {
        private readonly GameContext _game;
        private readonly DiContainer _diContainer;
        private readonly IGameFieldProvider _gameFieldProvider;
        private readonly ILinkedEntityRepository _linkedEntityRepository;

        public EnemyInitializeSystem(
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
            var enemies = _gameFieldProvider.GameField.Enemies;

            foreach (var enemyView in enemies)
            {
                var enemyTransform = enemyView.transform;
                var enemy = _game.CreateEnemy(enemyView.EnemyParameters, enemyTransform.position, enemyTransform.rotation);
            
                _diContainer.Inject(enemyView);
                enemyView.Link(enemy, _game);
                enemy.AddLink(enemyView);
                _linkedEntityRepository.Add(enemyTransform.GetHashCode(), enemy);
            }
        }
    }
}