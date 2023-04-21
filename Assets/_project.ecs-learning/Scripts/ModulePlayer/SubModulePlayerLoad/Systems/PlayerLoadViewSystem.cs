using _project.ecs_learning.Scripts.ModulePlayer.Configs;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerLoad.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerLoad.Systems
{
    public class PlayerLoadViewSystem : ISystem
    {
        private Filter _filter;
        private PlayerViewsCollection _playerViewsCollection;
        
        public World World { get; set; }

        public PlayerLoadViewSystem(PlayerViewsCollection playerViewsCollection)
        {
            _playerViewsCollection = playerViewsCollection;
        }
        
        public void OnAwake()
        {
            _filter = World.Filter
                .With<PlayerComponent>()
                .With<PlayerLoadMarker>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var playerComponent = ref entity.GetComponent<PlayerComponent>();
                var playerViews = _playerViewsCollection.Views;
                
                Object.Instantiate(playerViews[Random.Range(0, playerViews.Length)], playerComponent.transform);
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}