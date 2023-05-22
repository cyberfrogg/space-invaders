using System.Collections.Generic;
using Db.Bullet;
using Ecs.Core.Systems;
using Ecs.Game.Extensions;
using Ecs.Scheduler.Extensions;
using Ecs.Utils;
using Ecs.Views.Linkable.Impl;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Action.Systems.Shoot
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 300, nameof(EFeatures.Shooting))]
    public class PlayerShootSystem : AReactiveSystemWithPool<ActionEntity>
    {
        private readonly GameContext _game;
        private readonly SchedulerContext _scheduler;
        private readonly IBulletParametersBase _bulletParametersBase;

        public PlayerShootSystem(
            ActionContext action,
            GameContext game,
            SchedulerContext scheduler,
            IBulletParametersBase bulletParametersBase
            ) : base(action)
        {
            _game = game;
            _scheduler = scheduler;
            _bulletParametersBase = bulletParametersBase;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context)
            => context.CreateCollector(ActionMatcher.Shoot);

        protected override bool Filter(ActionEntity entity)
            => entity.HasShoot && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> actions)
        {
            foreach (var action in actions)
            {
                var owner = _game.GetEntityWithUid(action.Shoot.Owner);
                
                if (owner == null || !owner.IsPlayer)
                    continue;
                
                CreateBullet(owner);
            }
        }

        private void CreateBullet(GameEntity player)
        {
            var playerView = (PlayerView)player.Link.View;
            var bulletSpawnPoint = playerView.BulletSpawnPoint;
            
            var bulletVo = _bulletParametersBase.GetBullet(player.ActiveBulletType.Value);
            var bullet = _game.CreateBullet(player.Uid.Value, Vector2.up, bulletVo, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            _scheduler.CreateTimerAction(() =>
            {
                if(bullet.HasBullet && !bullet.IsDestroyed)
                    bullet.IsDestroyed = true;
            }, bulletVo.DespawnDelay);
        }
    }
}