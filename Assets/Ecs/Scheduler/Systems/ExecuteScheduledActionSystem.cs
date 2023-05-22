﻿using Ecs.Core.Interfaces;
using Ecs.Utils;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using JCMG.EntitasRedux;
using Zenject;

namespace Ecs.Scheduler.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 1970, nameof(EFeatures.Scheduler))]
    public class ExecuteScheduledActionSystem : IUpdateSystem
    {
        private static readonly ListPool<SchedulerEntity> SchedulerEntityListPool = ListPool<SchedulerEntity>.Instance;

        private readonly IGroup<SchedulerEntity> _actionGroup;
        private readonly ITimeProvider _timeProvider;

        public ExecuteScheduledActionSystem(SchedulerContext scheduler, ITimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
            _actionGroup = scheduler.GetGroup(SchedulerMatcher.AllOf(SchedulerMatcher.ScheduledAction,
                    SchedulerMatcher.Accumulator)
                .AnyOf(SchedulerMatcher.IntervalSec, SchedulerMatcher.TimerSec)
                .NoneOf(SchedulerMatcher.Paused, SchedulerMatcher.Destroyed));
        }

        public void Update()
        {
            var buffer = SchedulerEntityListPool.Spawn();
            _actionGroup.GetEntities(buffer);
            foreach (var action in buffer)
                action.ReplaceAccumulator(action.Accumulator.Value + _timeProvider.DeltaTime);

            SchedulerEntityListPool.Despawn(buffer);
        }
    }
}