using _project.ecs_learning.Scripts.ModuleEnemies.SubModuleEnemyDefeat.Components;
using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleStages.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleStages.Systems
{
    public class ScoreIncreaseSystem : ISystem
    {
        private Filter _defeatMarkerFilter;
        private Filter _stageDataFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _defeatMarkerFilter = World.Filter
                .With<EnemyDefeatMarker>()
                .Without<BlockMarker>();
            
            _stageDataFilter = World.Filter
                .With<CurrentStageData>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var defeatMarkerEntity in _defeatMarkerFilter)
            {
                foreach (var stageDataEntity in _stageDataFilter)
                {
                    ref var stageData = ref stageDataEntity.GetComponent<CurrentStageData>();
                    stageData.enemiesDefeated++;

                    if (stageData.enemiesDefeated >= stageData.defeatEnemiesToWin)
                    {
                        Entity entity = World.CreateEntity();
                        entity.SetComponent(new StageClearMarker());
                        entity.SetComponent(new BlockMarker());
                    }
                }
            }
        }

        public void Dispose()
        {
            _defeatMarkerFilter = null;
            _stageDataFilter = null;
        }
    }
}