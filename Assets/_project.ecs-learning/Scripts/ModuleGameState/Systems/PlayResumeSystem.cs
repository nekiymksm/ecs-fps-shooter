using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleGameState.Systems
{
    public class PlayResumeSystem : ISystem
    {
        private Filter _resumeMarkerFilter;
        private Filter _statePauseFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _resumeMarkerFilter = World.Filter
                .With<PlayResumeMarker>()
                .Without<BlockMarker>();
            
            _statePauseFilter = World.Filter
                .With<StatePause>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var resumeMarkerEntity in _resumeMarkerFilter)
            {
                foreach (var statePauseEntity in _statePauseFilter)
                {
                    statePauseEntity.SetComponent(new StatePlay());
                    statePauseEntity.RemoveComponent<StatePause>();
                }
            }
        }

        public void Dispose()
        {
            _resumeMarkerFilter = null;
            _statePauseFilter = null;
        }
    }
}