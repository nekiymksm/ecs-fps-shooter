using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Utilities;
using _project.ecs_learning.Scripts.ModuleMaps.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleMaps.Systems
{
    public class MapCollapseSystem : ISystem
    {
        private Filter _switchMarkerFilter;
        private Filter _mapFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _switchMarkerFilter = World.Filter
                .With<StateSwitchMarker>()
                .With<EntityCleanupMarker>()
                .Without<BlockMarker>();
            
            _mapFilter = World.Filter
                .With<MapComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var switchMarkerEntity in _switchMarkerFilter)
            {
                ref var switchMarker = ref switchMarkerEntity.GetComponent<StateSwitchMarker>();

                if (switchMarker.action is StateSwitchAction.End or StateSwitchAction.Next)
                {
                    foreach (var mapEntity in _mapFilter)
                    {
                        ref var mapComponent = ref mapEntity.GetComponent<MapComponent>();
                    
                        Object.Destroy(mapComponent.transform.gameObject);
                        World.RemoveEntity(mapEntity);
                    }
                }
            }
        }

        public void Dispose()
        {
            _switchMarkerFilter = null;
            _mapFilter = null;
        }
    }
}