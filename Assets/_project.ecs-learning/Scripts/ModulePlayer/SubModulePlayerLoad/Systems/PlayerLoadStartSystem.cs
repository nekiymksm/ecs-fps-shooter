using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModulePlayer.Configs;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerLoad.Components;
using _project.ecs_learning.Scripts.ModuleMaps.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerLoad.Systems
{
    public class PlayerLoadStartSystem : ISystem
    {
        private Filter _startMarkerFilter;
        private Filter _stageFilter;
        private PlayerViewsCollection _playerViewsCollection;

        public World World { get; set; }

        public PlayerLoadStartSystem(PlayerViewsCollection playerViewsCollection)
        {
            _playerViewsCollection = playerViewsCollection;
        }

        public void OnAwake()
        {
            _startMarkerFilter = World.Filter
                .With<PlayStartMarker>()
                .Without<BlockMarker>();
            
            _stageFilter = World.Filter
                .With<MapComponent>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var startMarkerEntity in _startMarkerFilter)
            {
                foreach (var stageEntity in _stageFilter)
                {
                    ref var stageComponent = ref stageEntity.GetComponent<MapComponent>();
                    
                    var player = Object.Instantiate(_playerViewsCollection.Prefab,
                        stageComponent.playerSpawnPointTransform.position, Quaternion.identity);

                    player.Entity.SetComponent(new PlayerLoadMarker());
                }
            }
        }
        
        public void Dispose()
        {
            _startMarkerFilter = null;
            _stageFilter = null;
        }
    }
}