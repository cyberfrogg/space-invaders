using Game.Providers;
using Game.Providers.Impl;
using Game.Utils;
using Zenject;

namespace Installers.Game
{
    public class LevelsInstaller : MonoInstaller
    {
        public GameField gameField;

        public override void InstallBindings()
        {
            var fieldProvider = new GameFieldProvider
            {
                GameField = gameField
            };

            Container.Bind<IGameFieldProvider>().FromInstance(fieldProvider).AsSingle();
        }
    }
}