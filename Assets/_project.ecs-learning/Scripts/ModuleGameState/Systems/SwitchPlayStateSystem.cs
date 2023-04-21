using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleGameState.Systems
{
    public class SwitchPlayStateSystem : ISystem
    {
        private Filter _startMarkerFilter;
        private Filter _stateStartFilter;
        
        public World World { get; set; }

        public void OnAwake()
        {
            _startMarkerFilter = World.Filter
                .With<PlayStartMarker>()
                .Without<BlockMarker>();
            
            _stateStartFilter = World.Filter
                .With<StateMainMenu>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var startMarkerEntity in _startMarkerFilter)
            {
                foreach (var stateStartEntity in _stateStartFilter)
                {
                    stateStartEntity.SetComponent(new StatePlay());
                    stateStartEntity.RemoveComponent<StateMainMenu>();
                }
            }
        }

        public void Dispose()
        {
            _startMarkerFilter = null;
            _stateStartFilter = null;
        }
    }
}