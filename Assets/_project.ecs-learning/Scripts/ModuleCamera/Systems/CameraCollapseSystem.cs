using _project.ecs_learning.Scripts.ModuleCamera.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleCamera.Systems
{
    public class CameraCollapseSystem : ISystem
    {
        private Filter _endMarkerFilter;
        private Filter _cameraFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _endMarkerFilter = World.Filter
                .With<PlayEndMarker>()
                .Without<BlockMarker>();
            
            _cameraFilter = World.Filter
                .With<CameraComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var endMarkerEntity in _endMarkerFilter)
            {
                foreach (var cameraEntity in _cameraFilter)
                {
                    ref var cameraComponent = ref cameraEntity.GetComponent<CameraComponent>();
                    
                    cameraEntity
                        .SetComponent(new EntityCleanupMarker {itemToDestroyTransform = cameraComponent.transform});
                }
            }
        }

        public void Dispose()
        {
            _endMarkerFilter = null;
            _cameraFilter = null;
        }
    }
}