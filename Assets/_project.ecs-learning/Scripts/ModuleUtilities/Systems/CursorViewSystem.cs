using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleStages.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleUtilities.Systems
{
    public class CursorViewSystem : ISystem
    {
        private Filter _startMarkerFilter;
        private Filter _pauseMarkerFilter;
        private Filter _resumeMarkerFilter;
        private Filter _endMarkerFilter;
        private Filter _stageClearMarkerFilter;
        
        public World World { get; set; }
        
        public void OnAwake()
        {
            _startMarkerFilter = World.Filter.With<PlayStartMarker>().Without<BlockMarker>();
            _pauseMarkerFilter = World.Filter.With<PlayPauseMarker>().Without<BlockMarker>();
            _resumeMarkerFilter = World.Filter.With<PlayResumeMarker>().Without<BlockMarker>();
            _endMarkerFilter = World.Filter.With<PlayEndMarker>().Without<BlockMarker>();
            _stageClearMarkerFilter = World.Filter.With<PlayClearMarker>().Without<BlockMarker>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _startMarkerFilter)
            {
                Set(false);
            }
            
            foreach (var entity in _pauseMarkerFilter)
            {
                Set(true);
            }

            foreach (var entity in _resumeMarkerFilter)
            {
                Set(false);
            }
            
            foreach (var entity in _endMarkerFilter)
            {
                Set(true);
            }
            
            foreach (var entity in _stageClearMarkerFilter)
            {
                Set(true);
            }
        }
        
        public void Dispose()
        {
            _startMarkerFilter = null;
            _pauseMarkerFilter = null;
            _resumeMarkerFilter = null;
            _endMarkerFilter = null;
            _stageClearMarkerFilter = null;
        }

        private void Set(bool isVisible)
        {
            Cursor.lockState = isVisible ? CursorLockMode.Confined : CursorLockMode.Locked;
            Cursor.visible = isVisible;
        }
    }
}