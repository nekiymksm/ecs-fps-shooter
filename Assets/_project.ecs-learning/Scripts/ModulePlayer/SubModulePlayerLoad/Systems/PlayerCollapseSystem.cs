using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerLoad.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerLoad.Systems
{
    public class PlayerCollapseSystem : ISystem
    {
        private Filter _endMarkerFilter;
        private Filter _playerFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _endMarkerFilter = World.Filter
                .With<PlayEndMarker>()
                .Without<BlockMarker>();
            
            _playerFilter = World.Filter
                .With<PlayerComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var endMarkerEntity in _endMarkerFilter)
            {
                foreach (var playerEntity in _playerFilter)
                {
                    ref var enemyComponent = ref playerEntity.GetComponent<PlayerComponent>();
                    playerEntity.SetComponent(new EntityCleanupMarker {itemToDestroyTransform = enemyComponent.transform});
                }
            }
        }

        public void Dispose()
        {
            _endMarkerFilter = null;
            _playerFilter = null;
        }
    }
}