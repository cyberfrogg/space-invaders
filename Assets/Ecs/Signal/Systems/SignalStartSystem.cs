using System.Collections.Generic;
using Ecs.Core.Systems;
using Ecs.Utils;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using JCMG.EntitasRedux;
using PdUtils.Interfaces;

namespace Ecs.Signal.Systems
{
	[Install(ExecutionType.Game, ExecutionPriority.Low, 2000, nameof(EFeatures.Initialization))]
	public class SignalStartSystem : AReactiveSystemWithPool<SignalEntity>
	{
		private readonly List<IUiInitializable> _uiInitializables;

		public SignalStartSystem(
			SignalContext signal,
			List<IUiInitializable> uiInitializables
		) : base(signal)
		{
			_uiInitializables = uiInitializables;
		}

		protected override ICollector<SignalEntity> GetTrigger(IContext<SignalEntity> context) =>
			context.CreateCollector(SignalMatcher.SignalStart);

		protected override bool Filter(SignalEntity entity) => entity.IsSignalStart && !entity.IsDestroyed;

		protected override void Execute(List<SignalEntity> entities)
		{
			foreach (var signal in entities)
			{
				signal.IsDestroyed = true;

				foreach (var uiInitializable in _uiInitializables)
				{
					uiInitializable.Initialize();
				}
			}
		}
	}
}