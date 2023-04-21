using _project.ecs_learning.Scripts.ModuleCamera.Components;
using _project.ecs_learning.Scripts.ModuleCamera.Configs;
using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleCamera.Systems
{
    public class CameraLoadSystem : ISystem
    {
        private Filter _filter;
        private PlayerCameraConfig _playerCameraConfig;
        
        public World World { get; set; }
        
        public CameraLoadSystem(PlayerCameraConfig playerCameraConfig)
        {
            _playerCameraConfig = playerCameraConfig;
        }
        
        public void OnAwake()
        {
            _filter = World.Filter
                .With<PlayStartMarker>()
                .Without<BlockMarker>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                Object.Instantiate(_playerCameraConfig.Prefab)
                    .Entity.SetComponent(new CameraSightData());
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}