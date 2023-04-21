using _project.ecs_learning.Scripts.ModuleCamera.Components;
using _project.ecs_learning.Scripts.ModuleCamera.Configs;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleCamera.Systems
{
    public class CameraSightSystem : ISystem
    {
        private Filter _movementDataFilter;
        private Filter _cameraFilter;
        private PlayerCameraConfig _playerCameraConfig;

        public World World { get; set; }

        public CameraSightSystem(PlayerCameraConfig playerCameraConfig)
        {
            _playerCameraConfig = playerCameraConfig;
        }
        
        public void OnAwake()
        {
            _movementDataFilter = World.Filter
                .With<PlayerMovementInputData>();
            
            _cameraFilter = World.Filter
                .With<CameraComponent>()
                .With<CameraSightData>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var movementDataEntity in _movementDataFilter)
            {
                ref var movementData = ref movementDataEntity.GetComponent<PlayerMovementInputData>();

                foreach (var cameraEntity in _cameraFilter)
                {
                    ref var cameraComponent = ref cameraEntity.GetComponent<CameraComponent>();
                    ref var sightData = ref cameraEntity.GetComponent<CameraSightData>();
                    
                    sightData.sightVerticalValue -= 
                        movementData.sightVerticalDirectionValue * _playerCameraConfig.VerticalSightSpeed;
                    sightData.sightHorizontalValue += 
                        movementData.sightHorizontalDirectionValue * _playerCameraConfig.HorizontalSightSpeed;
                    
                    sightData.sightVerticalValue = Mathf.Clamp(sightData.sightVerticalValue, 
                        _playerCameraConfig.MinVerticalValue, _playerCameraConfig.MaxVerticalValue);
                    
                    cameraComponent.transform.rotation = 
                        Quaternion.Euler(sightData.sightVerticalValue, sightData.sightHorizontalValue, 0);
                }
            }
        }
        
        public void Dispose()
        {
            _movementDataFilter = null;
            _cameraFilter = null;
        }
    }
}