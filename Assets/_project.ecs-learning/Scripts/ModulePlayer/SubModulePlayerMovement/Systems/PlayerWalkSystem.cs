using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerLoad.Components;
using _project.ecs_learning.Scripts.ModulePlayer.Configs;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerMovement.Systems
{
    public class PlayerWalkSystem : ISystem
    {
        private Filter _filter;
        private PlayerMovementConfig _playerMovementConfig;

        public World World { get; set; }

        public PlayerWalkSystem(PlayerMovementConfig playerMovementConfig)
        {
            _playerMovementConfig = playerMovementConfig;
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

                float horizontalValue = inputData.walkHorizontalValue * _playerMovementConfig.WalkSpeed;
                float verticalValue = inputData.walkVerticalValue * _playerMovementConfig.WalkSpeed;

                var moveDirection = playerComponent.transform
                    .TransformDirection(horizontalValue, 0, verticalValue);

                playerComponent.characterController.SimpleMove(moveDirection);
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}