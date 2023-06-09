﻿using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Utilities;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerIndicators.Systems
{
    public class PlayerIndicatorsHideSystem : ISystem
    {
        private Filter _filter;
        private UiRoot _uiRoot;

        public World World { get; set; }
        
        public PlayerIndicatorsHideSystem(UiRoot uiRoot)
        {
            _uiRoot = uiRoot;
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
                
                if (switchMarker.action is StateSwitchAction.End or StateSwitchAction.Result)
                {
                    _uiRoot.GetWindow<PlayerIndicators>().gameObject.SetActive(false);
                }
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}