using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleStages.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleStages.Systems
{
    public class StageRestartSystem : ISystem
    {
        private Filter _startMarkerFilter;
        private Filter _stageDataFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _startMarkerFilter = World.Filter
                .With<PlayRestartMarker>()
                .Without<BlockMarker>();
            
            _stageDataFilter = World.Filter
                .With<CurrentStageData>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var startMarkerEntity in _startMarkerFilter)
            {
                foreach (var stageDataEntity in _stageDataFilter)
                {
                    ref var stageData = ref stageDataEntity.GetComponent<CurrentStageData>();
                    stageData.stagesCleared = 0;
                }
            }
        }

        public void Dispose()
        {
            _startMarkerFilter = null;
            _stageDataFilter = null;
        }
    }
}