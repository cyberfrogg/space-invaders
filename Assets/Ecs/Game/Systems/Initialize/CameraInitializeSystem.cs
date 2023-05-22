using Ecs.Game.Extensions;
using Ecs.Utils;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using JCMG.EntitasRedux;

namespace Ecs.Game.Systems.Initialize
{
	[Install(ExecutionType.Game, ExecutionPriority.High, 20, nameof(EFeatures.Initialization))]
	public class CameraInitializeSystem : IInitializeSystem
	{
		private readonly GameContext _game;

		public CameraInitializeSystem(
			GameContext game
		)
		{
			_game = game;
		}

		public void Initialize()
		{
			_game.CreateCamera();
			_game.CreateVirtualCamera();
		}
	}
}