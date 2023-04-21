using _project.ecs_learning.Scripts.ModuleEnemies.SubModuleEnemiesLoad.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleEnemies.SubModuleEnemiesLoad.Systems
{
    public class EnemiesCollapseSystem : ISystem
    {
        private Filter _endMarkerFilter;
        private Filter _enemyFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _endMarkerFilter = World.Filter
                .With<PlayEndMarker>()
                .Without<BlockMarker>();
            
            _enemyFilter = World.Filter
                .With<EnemyComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var endMarkerEntity in _endMarkerFilter)
            {
                foreach (var enemyEntity in _enemyFilter)
                {
                    ref var enemyComponent = ref enemyEntity.GetComponent<EnemyComponent>();
                    enemyEntity.SetComponent(new EntityCleanupMarker {itemToDestroyTransform = enemyComponent.transform});
                }
            }
        }

        public void Dispose()
        {
            _endMarkerFilter = null;
            _enemyFilter = null;
        }
    }
}