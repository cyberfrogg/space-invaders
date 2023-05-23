using System.Collections.Generic;
using Ecs.Core.Systems;
using Ecs.Scheduler.Extensions;
using Ecs.Utils;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using JCMG.EntitasRedux;
using Zenject;

namespace Ecs.Game.Systems.Enemy
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 300, nameof(EFeatures.PickupItems))]
    public class RespawnEnemySystem : AReactiveSystemWithPool<GameEntity>
    {
        private readonly SchedulerContext _scheduler;
        private static readonly ListPool<GameEntity> ListPool = ListPool<GameEntity>.Instance;
        
        private readonly IGroup<GameEntity> _deadEnemiesGroup;
        private readonly IGroup<GameEntity> _aliveEnemiesGroup;
        
        public RespawnEnemySystem(
            GameContext game,
            SchedulerContext scheduler
            ) : base(game)
        {
            _scheduler = scheduler;
            _deadEnemiesGroup = game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.Dead).NoneOf(GameMatcher.Destroyed));
            _aliveEnemiesGroup = game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy).NoneOf(GameMatcher.Dead, GameMatcher.Destroyed));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
            => context.CreateCollector(GameMatcher.Dead);

        protected override bool Filter(GameEntity entity)
            => entity.HasEnemy && entity.IsDead && !entity.IsDestroyed;

        protected override void Execute(List<GameEntity> entities)
        {
            var enemiesCount = _aliveEnemiesGroup.Count;

            if (enemiesCount <= 0)
            {
                _scheduler.CreateTimerAction(RespawnEnemies, 2f);
            }
        }

        private void RespawnEnemies()
        {
            var buffer = ListPool.Spawn();
            _deadEnemiesGroup.GetEntities(buffer);
                
            foreach (var enemy in buffer)
            {
                var enemyParameters = enemy.EnemyParameters.Value;
                enemy.ReplaceHealth(enemyParameters.MaxHealth);
                enemy.IsDead = false;
            }
                
            ListPool.Despawn(buffer);
        }
    }
}