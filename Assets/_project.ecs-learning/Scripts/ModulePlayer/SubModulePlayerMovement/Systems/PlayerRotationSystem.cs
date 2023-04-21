using _project.ecs_learning.Scripts.ModuleCamera.Configs;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Components;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerLoad.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerMovement.Systems
{
    public class PlayerRotationSystem : ISystem
    {
        private Filter _filter;
        private PlayerCameraConfig _playerCameraConfig;
        
        public World World { get; set; }

        public PlayerRotationSystem(PlayerCameraConfig playerCameraConfig)
        {
            _playerCameraConfig = playerCameraConfig;
        }
        
        public void OnAwake()
        {
            _filter = World.Filter
                .With<PlayerComponent>()
                .With<PlayerMovementInputData>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var playerComponent = ref entity.GetComponent<PlayerComponent>();
                ref var inputData = ref entity.GetComponent<PlayerMovementInputData>();

                float rotationValue = 
                    inputData.sightHorizontalDirectionValue * _playerCameraConfig.HorizontalSightSpeed;
                
                if (rotationValue != 0)
                {
                    playerComponent.transform.Rotate(0, rotationValue, 0);
                }
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}