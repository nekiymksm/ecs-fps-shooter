using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleStages.Components;
using _project.ecs_learning.Scripts.ModuleStages.Configs;
using _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerIndicators.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleStages.Systems
{
    public class NextStageSystem : ISystem
    {
        private Filter _nextMarkerFilter;
        private Filter _stageDataFilter;
        private StageInfosCollection _stageInfosCollection;

        public World World { get; set; }

        public NextStageSystem(StageInfosCollection stageInfosCollection)
        {
            _stageInfosCollection = stageInfosCollection;
        }

        public void OnAwake()
        {
            _nextMarkerFilter = World.Filter
                .With<PlayNextMarker>()
                .Without<BlockMarker>();

            _stageDataFilter = World.Filter
                .With<CurrentStageData>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var nextMarkerEntity in _nextMarkerFilter)
            {
                foreach (var stageDataEntity in _stageDataFilter)
                {
                    var infos = _stageInfosCollection.StageInfos;
                    var stageInfo = infos[Random.Range(0, infos.Length)];
                    
                    ref var stageData = ref stageDataEntity.GetComponent<CurrentStageData>();

                    stageData.stageId = stageInfo.StageId;
                    stageData.enemiesToWin = stageInfo.EnemiesCountToWin;
                    stageData.enemiesDefeated = 0;
                    
                    Entity entity = World.CreateEntity();
                    entity.SetComponent(new EnemiesCountSetMarker());
                    entity.SetComponent(new BlockMarker());
                }
            }
        }

        public void Dispose()
        {
            _nextMarkerFilter = null;
            _stageDataFilter = null;
        }
    }
}