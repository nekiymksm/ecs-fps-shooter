using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleStages.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleStages.Systems
{
    public class StageDataClearSystem : ISystem
    {
        private Filter _endMarkerFilter;
        private Filter _stageDataFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _endMarkerFilter = World.Filter
                .With<PlayEndMarker>()
                .Without<BlockMarker>();
            
            _stageDataFilter = World.Filter
                .With<CurrentStageData>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var endMarkerEntity in _endMarkerFilter)
            {
                foreach (var stageDataEntity in _stageDataFilter)
                {
                    World.RemoveEntity(stageDataEntity);
                }
            }
        }

        public void Dispose()
        {
            _endMarkerFilter = null;
            _stageDataFilter = null;
        }
    }
}