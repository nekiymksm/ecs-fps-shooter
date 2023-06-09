﻿using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Utilities;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Components;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerLoad.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Systems
{
    public class PlayerInputUnblockSystem : ISystem
    {
        private Filter _switchMarkerFilter;
        private Filter _playerFilter;
        
        public World World { get; set; }

        public void OnAwake()
        {
            _switchMarkerFilter = World.Filter
                .With<StateSwitchMarker>()
                .With<EntityCleanupMarker>()
                .Without<BlockMarker>();
            
            _playerFilter = World.Filter
                .With<PlayerComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var switchMarkerEntity in _switchMarkerFilter)
            {
                ref var switchMarker = ref switchMarkerEntity.GetComponent<StateSwitchMarker>();

                if (switchMarker.action is StateSwitchAction.Resume or StateSwitchAction.Next)
                {
                    foreach (var playerEntity in _playerFilter)
                    {
                        ref var playerComponent = ref playerEntity.GetComponent<PlayerComponent>();
                        
                        playerEntity.SetComponent(new PlayerShootingInputData {weaponEntity = playerComponent.weapon.Entity});
                        playerEntity.SetComponent(new PlayerMovementInputData());
                    }
                }
            }
        }
        
        public void Dispose()
        {
            _switchMarkerFilter = null;
            _playerFilter = null;
        }
    }
}