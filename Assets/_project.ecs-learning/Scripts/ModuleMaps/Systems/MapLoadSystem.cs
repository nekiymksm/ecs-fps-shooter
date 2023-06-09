﻿using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Utilities;
using _project.ecs_learning.Scripts.ModuleMaps.Configs;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleMaps.Systems
{
    public class MapLoadSystem : ISystem
    {
        private Filter _filter;
        private MapsCollection _mapsCollection;

        public World World { get; set; }

        public MapLoadSystem(MapsCollection mapsCollection)
        {
            _mapsCollection = mapsCollection;
        }
        
        public void OnAwake()
        {
            _filter = World.Filter
                .With<StateSwitchMarker>()
                .With<EntityCleanupMarker>()
                .Without<BlockMarker>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var switchMarker = ref entity.GetComponent<StateSwitchMarker>();

                if (switchMarker.action is StateSwitchAction.Start or StateSwitchAction.Next)
                {
                    var mapPrefabs = _mapsCollection.Prefabs;
                    Object.Instantiate(mapPrefabs[Random.Range(0, mapPrefabs.Length)]);
                }
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}