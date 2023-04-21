using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleMaps.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleMaps.Systems
{
    public class MapCollapseSystem : ISystem
    {
        private Filter _endMarkerFilter;
        private Filter _mapFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _endMarkerFilter = World.Filter
                .With<PlayEndMarker>()
                .Without<BlockMarker>();
            
            _mapFilter = World.Filter
                .With<MapComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var endMarkerEntity in _endMarkerFilter)
            {
                foreach (var mapEntity in _mapFilter)
                {
                    ref var mapComponent = ref mapEntity.GetComponent<MapComponent>();
                    
                    mapEntity
                        .SetComponent(new EntityCleanupMarker {itemToDestroyTransform = mapComponent.transform});
                }
            }
        }

        public void Dispose()
        {
            _endMarkerFilter = null;
            _mapFilter = null;
        }
    }
}