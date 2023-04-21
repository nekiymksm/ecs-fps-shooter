using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleStages.Components;
using _project.ecs_learning.Scripts.ModuleUi.SubModuleStageClearMenu.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModuleStageClearMenu.Systems
{
    public class ClearedStageInfoSetSystem : ISystem
    {
        private Filter _stageClearFilter;
        private Filter _stageDataFilter;
        private Filter _stageClearMenuFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _stageClearFilter = World.Filter
                .With<StageClearMarker>()
                .Without<BlockMarker>();
            
            _stageDataFilter = World.Filter
                .With<CurrentStageData>();

            _stageClearMenuFilter = World.Filter
                .With<StageClearMenuComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var stageClearEntity in _stageClearFilter)
            {
                foreach (var stageDataEntity in _stageDataFilter)
                {
                    foreach (var stageClearMenuEntity in _stageClearMenuFilter)
                    {
                        ref var stageClearMenu = ref stageClearMenuEntity.GetComponent<StageClearMenuComponent>();
                        ref var stageData = ref stageDataEntity.GetComponent<CurrentStageData>();
                        
                        stageClearMenu.stageId.SetText($"{stageData.stageId}");
                        stageClearMenu.kills.SetText($"{stageData.enemiesDefeated}");
                        stageClearMenu.stagesCleared.SetText($"{stageData.stagesCleared}");
                    }
                }
            }
        }

        public void Dispose()
        {
            _stageClearFilter = null;
            _stageDataFilter = null;
            _stageClearMenuFilter = null;
        }
    }
}