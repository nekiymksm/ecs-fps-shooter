using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Systems
{
    public class PlayerInputBlockSystem : ISystem
    {
        private Filter _pauseMarkerFilter;
        private Filter _playerFilter;
        
        public World World { get; set; }

        public void OnAwake()
        {
            _pauseMarkerFilter = World.Filter
                .With<PlayPauseMarker>()
                .Without<BlockMarker>();
            
            _playerFilter = World.Filter
                .With<PlayerMovementInputData>()
                .With<PlayerShootingInputData>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var pauseMarkerEntity in _pauseMarkerFilter)
            {
                foreach (var playerEntity in _playerFilter)
                {
                    playerEntity.RemoveComponent<PlayerMovementInputData>();
                    playerEntity.RemoveComponent<PlayerShootingInputData>();
                }
            }
        }
        
        public void Dispose()
        {
            _pauseMarkerFilter = null;
            _playerFilter = null;
        }
    }
}