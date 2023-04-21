using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleGameState.Systems
{
    public class PlayPauseSystem : ISystem
    {
        private Filter _pauseMarkerFilter;
        private Filter _statePlayFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _pauseMarkerFilter = World.Filter
                .With<PlayPauseMarker>()
                .Without<BlockMarker>();
            
            _statePlayFilter = World.Filter
                .With<StatePlay>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var pauseMarkerEntity in _pauseMarkerFilter)
            {
                foreach (var statePlayEntity in _statePlayFilter)
                {
                    statePlayEntity.SetComponent(new StatePause());
                    statePlayEntity.RemoveComponent<StatePlay>();
                }
            }
        }

        public void Dispose()
        {
            _pauseMarkerFilter = null;
            _statePlayFilter = null;
        }
    }
}