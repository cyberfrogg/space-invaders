using System.Collections.Generic;
using Ecs.Core.Systems;
using Ecs.Utils;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using JCMG.EntitasRedux;

namespace Ecs.Action.Systems.Shoot
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 2000, nameof(EFeatures.Shoot))]
    public class ShootDestroySystem : AReactiveSystemWithPool<ActionEntity>
    {
        public ShootDestroySystem(
            ActionContext action
            ) : base(action)
        {
            
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context)
            => context.CreateCollector(ActionMatcher.Shoot);

        protected override bool Filter(ActionEntity entity)
            => entity.HasShoot && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> actions)
        {
            foreach (var action in actions)
            {
                action.IsDestroyed = true;
            }
        }
    }
}