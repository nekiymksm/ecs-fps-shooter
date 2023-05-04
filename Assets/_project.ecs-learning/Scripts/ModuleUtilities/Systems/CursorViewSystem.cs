using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Utilities;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleUtilities.Systems
{
    public class CursorViewSystem : ISystem
    {
        private Filter _switchMarkerFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _switchMarkerFilter = World.Filter
                .With<StateSwitchMarker>()
                .With<EntityCleanupMarker>()
                .Without<BlockMarker>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _switchMarkerFilter)
            {
                ref var switchMarker = ref entity.GetComponent<StateSwitchMarker>();
                
                switch (switchMarker.action)
                {
                    case StateSwitchAction.Start:
                        Set(false);
                        break;
                    case StateSwitchAction.Pause:
                        Set(true);
                        break;
                    case StateSwitchAction.ShowWeapons:
                        Set(true);
                        break;
                    case StateSwitchAction.Resume:
                        Set(false);
                        break;
                    case StateSwitchAction.Defeat:
                        Set(true);
                        break;
                    case StateSwitchAction.Result:
                        Set(true);
                        break;
                    case StateSwitchAction.Next:
                        Set(false);
                        break;
                }
            }
        }
        
        public void Dispose()
        {
            _switchMarkerFilter = null;
        }

        private void Set(bool isVisible)
        {
            Cursor.lockState = isVisible ? CursorLockMode.Confined : CursorLockMode.Locked;
            Cursor.visible = isVisible;
        }
    }
}