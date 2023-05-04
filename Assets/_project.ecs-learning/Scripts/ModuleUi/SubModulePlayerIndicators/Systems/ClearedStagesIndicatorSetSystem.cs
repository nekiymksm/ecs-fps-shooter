using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleStages.Components;
using _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerIndicators.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerIndicators.Systems
{
    public class ClearedStagesIndicatorSetSystem : ISystem
    {
        private Filter _setMarkerFilter;
        private Filter _stageDataFilter;
        private Filter _playerIndicatorsFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _setMarkerFilter = World.Filter.With<ClearedStagesIndicatorSetMarker>();
            _stageDataFilter = World.Filter.With<CurrentStageData>();
            _playerIndicatorsFilter = World.Filter.With<PlayerIndicatorsComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var setMarkerEntity in _setMarkerFilter)
            {
                foreach (var stageDataEntity in _stageDataFilter)
                {
                    foreach (var playerIndicatorsEntity in _playerIndicatorsFilter)
                    {
                        ref var stageData = ref stageDataEntity.GetComponent<CurrentStageData>();
                        ref var indicatorsComponent = ref playerIndicatorsEntity.GetComponent<PlayerIndicatorsComponent>();

                        indicatorsComponent.clearStagesText.SetText($"{stageData.stagesCleared}");
                    }
                }
                
                World.RemoveEntity(setMarkerEntity);
            }
        }

        public void Dispose()
        {
            _setMarkerFilter = null;
            _stageDataFilter = null;
            _playerIndicatorsFilter = null;
        }
    }
}