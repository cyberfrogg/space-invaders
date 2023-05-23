using Ecs.Utils;
using Game.Ui;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using JCMG.EntitasRedux;
using SimpleUi.Signals;
using UnityEngine;
using Zenject;

namespace Ecs.Game.Systems.Initialize
{
	[Install(ExecutionType.Game, ExecutionPriority.High, 10, nameof(EFeatures.Initialization))]
	public class GameInitializeSystem : IInitializeSystem
	{
		private readonly SignalBus _signalBus;
		private readonly SignalContext _signal;
		private readonly GameContext _game;

		protected GameInitializeSystem(
			SignalBus signalBus,
			SignalContext signal,
			GameContext game
		)
		{
			_signalBus = signalBus;
			_signal = signal;
			_game = game;
		}

		public void Initialize()
		{
			Debug.Log("GameInitializeSystem");

			_game.SetTotalScore(0);

			_signal.CreateEntity().IsSignalStart = true;
			_signalBus.OpenWindow<GameHudWindow>();
		}
	}
}