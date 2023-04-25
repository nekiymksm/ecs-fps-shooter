using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleStages.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleStages.Systems
{
    public class ClearedStagesIncreaseSystem : ISystem
    {
        private Filter _clearMarkerFilter;
        private Filter _stageDataFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _clearMarkerFilter = World.Filter
                .With<PlayClearMarker>()
                .Without<BlockMarker>();
            
            _stageDataFilter = World.Filter
                .With<CurrentStageData>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var clearMarkerEntity in _clearMarkerFilter)
            {
                foreach (var stageDataEntity in _stageDataFilter)
                {
                    ref var stageData = ref stageDataEntity.GetComponent<CurrentStageData>();
                    stageData.stagesCleared++;
                }
            }
        }

        public void Dispose()
        {
            _clearMarkerFilter = null;
            _stageDataFilter = null;
        }
    }
}