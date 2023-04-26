using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleMaps.Components;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerMovement.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerLoad.Systems
{
    public class PlayerSetOnSpawnPointSystem : ISystem
    {
        private Filter _nextMarkerFilter;
        private Filter _mapFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _nextMarkerFilter = World.Filter
                .With<PlayNextMarker>()
                .Without<BlockMarker>();
            
            _mapFilter = World.Filter
                .With<MapComponent>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var nextMarkerEntity in _nextMarkerFilter)
            {
                foreach (var mapEntity in _mapFilter)
                {
                    ref var stage = ref mapEntity.GetComponent<MapComponent>();
                    
                    World.CreateEntity()
                        .SetComponent(new TeleportPlayerMarker {position = stage.playerSpawnPointTransform.position});  
                }
            }
        }
        
        public void Dispose()
        {
            _nextMarkerFilter = null;
            _mapFilter = null;
        }
    }
}