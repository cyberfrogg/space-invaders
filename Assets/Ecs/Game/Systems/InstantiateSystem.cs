using System.Collections.Generic;
using Ecs.Core.Systems;
using Ecs.Utils;
using Ecs.Views.Linkable;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using JCMG.EntitasRedux;

namespace Ecs.Game.Systems
{
	[Install(ExecutionType.Game, ExecutionPriority.Normal, 700, nameof(EFeatures.Initialization))]
	public class InstantiateSystem : AReactiveSystemWithPool<GameEntity>
	{
		private readonly GameContext _game;
		private readonly ILinkedEntityRepository _linkedEntityRepository;
		private readonly ISpawnService<GameEntity, ILinkable> _spawnService;

		public InstantiateSystem(
			GameContext game,
			ILinkedEntityRepository linkedEntityRepository,
			ISpawnService<GameEntity, ILinkable> spawnService
		) : base(game)
		{
			_game = game;
			_linkedEntityRepository = linkedEntityRepository;
			_spawnService = spawnService;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
			context.CreateCollector(GameMatcher.Instantiate.Added());

		protected override bool Filter(GameEntity entity) => entity.IsInstantiate && !entity.IsDestroyed;

		protected override void Execute(List<GameEntity> entities)
		{
			for (var i = 0; i < entities.Count; i++)
			{
				var entity = entities[i];
				var linkable = _spawnService.Spawn(entity);
				if (linkable == null)
					continue;

				linkable.Link(entity, _game);
				_linkedEntityRepository.Add(linkable.Hash, entity);
				entity.ReplaceLink(linkable);
			}
		}
	}
}