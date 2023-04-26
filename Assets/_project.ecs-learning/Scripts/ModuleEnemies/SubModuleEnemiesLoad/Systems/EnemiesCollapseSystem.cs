using _project.ecs_learning.Scripts.ModuleEnemies.SubModuleEnemiesLoad.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Utilities;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleEnemies.SubModuleEnemiesLoad.Systems
{
    public class EnemiesCollapseSystem : ISystem
    {
        private Filter _switchMarkerFilter;
        private Filter _enemyFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _switchMarkerFilter = World.Filter
                .With<StateSwitchMarker>()
                .With<EntityCleanupMarker>()
                .Without<BlockMarker>();
            
            _enemyFilter = World.Filter
                .With<EnemyComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var switchMarkerEntity in _switchMarkerFilter)
            {
                ref var switchMarker = ref switchMarkerEntity.GetComponent<StateSwitchMarker>();
                
                if (switchMarker.action is StateSwitchAction.End or StateSwitchAction.Next)
                {
                    foreach (var enemyEntity in _enemyFilter)
                    {
                        ref var enemyComponent = ref enemyEntity.GetComponent<EnemyComponent>();
                        enemyEntity.SetComponent(new EntityCleanupMarker {itemToDestroyTransform = enemyComponent.transform});
                    }
                }
            }
        }

        public void Dispose()
        {
            _switchMarkerFilter = null;
            _enemyFilter = null;
        }
    }
}