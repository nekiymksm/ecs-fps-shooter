using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerLoad.Components;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerMovement.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerMovement.Systems
{
    public class TeleportPlayerSystem : ISystem
    {
        private Filter _resetMarkerFilter;
        private Filter _playerFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _resetMarkerFilter = World.Filter.With<TeleportPlayerMarker>();
            _playerFilter = World.Filter.With<PlayerComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var teleportMarkerEntity in _resetMarkerFilter)
            {
                foreach (var playerEntity in _playerFilter)
                {
                    ref var teleportMarker = ref teleportMarkerEntity.GetComponent<TeleportPlayerMarker>();
                    ref var player = ref playerEntity.GetComponent<PlayerComponent>();

                    player.characterController.enabled = false;
                    player.transform.position = teleportMarker.position;
                    player.characterController.enabled = true;
                    
                    World.RemoveEntity(teleportMarkerEntity);
                }
            }
        }

        public void Dispose()
        {
            _resetMarkerFilter = null;
            _playerFilter = null;
        }
    }
}