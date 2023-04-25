using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleStages.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleUtilities.Systems
{
    public class TimeScaleSwitchSystem : ISystem
    {
        private Filter _pauseMarkerFilter;
        private Filter _resumeMarkerFilter;
        private Filter _endMarkerFilter;
        private Filter _stageClearMarkerFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _pauseMarkerFilter = World.Filter.With<PlayPauseMarker>().Without<BlockMarker>();
            _resumeMarkerFilter = World.Filter.With<PlayResumeMarker>().Without<BlockMarker>();
            _endMarkerFilter = World.Filter.With<PlayEndMarker>().Without<BlockMarker>();
            _stageClearMarkerFilter = World.Filter.With<PlayClearMarker>().Without<BlockMarker>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var pauseMarkerEntity in _pauseMarkerFilter)
            {
                Set(true);
            }
            
            foreach (var resumeMarkerEntity in _resumeMarkerFilter)
            {
                Set(false);
            }
            
            foreach (var endMarkerEntity in _endMarkerFilter)
            {
                Set(false);
            }
            
            foreach (var pauseMarkerEntity in _stageClearMarkerFilter)
            {
                Set(true);
            }
        }
        
        public void Dispose()
        {
            _pauseMarkerFilter = null;
            _resumeMarkerFilter = null;
            _endMarkerFilter = null;
            _stageClearMarkerFilter = null;
        }

        private void Set(bool isPause)
        {
            Time.timeScale = isPause ? 0.0f : 1.0f;
        }
    }
}