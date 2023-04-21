using _project.ecs_learning.Scripts.ModuleCamera.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleCamera.Systems
{
    public class CameraTrackSystem : ISystem
    {
        private Filter _trackFilter;
        private Filter _cameraFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _trackFilter = World.Filter.With<CameraTrackData>();
            _cameraFilter = World.Filter.With<CameraComponent>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var trackEntity in _trackFilter)
            {
                ref var cameraTrackComponent = ref trackEntity.GetComponent<CameraTrackData>();

                foreach (var cameraEntity in _cameraFilter)
                {
                    ref var cameraComponent = ref cameraEntity.GetComponent<CameraComponent>();
                    
                    cameraComponent.transform.position = cameraTrackComponent.trackTransform.position;
                }
            }
        }
        
        public void Dispose()
        {
            _cameraFilter = null;
            _trackFilter = null;
        }
    }
}