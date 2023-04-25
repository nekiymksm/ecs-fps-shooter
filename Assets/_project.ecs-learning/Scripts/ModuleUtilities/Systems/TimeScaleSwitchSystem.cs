using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Utilities;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleUtilities.Systems
{
    public class TimeScaleSwitchSystem : ISystem
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
                    case StateSwitchAction.Pause:
                        Set(true);
                        break;
                    case StateSwitchAction.Resume:
                        Set(false);
                        break;
                    case StateSwitchAction.Result:
                        Set(true);
                        break;
                    case StateSwitchAction.End:
                        Set(false);
                        break;
                }
            }
        }
        
        public void Dispose()
        {
            _switchMarkerFilter = null;
        }

        private void Set(bool isPause)
        {
            Time.timeScale = isPause ? 0.0f : 1.0f;
        }
    }
}