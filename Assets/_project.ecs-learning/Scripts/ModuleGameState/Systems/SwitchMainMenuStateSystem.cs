using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleGameState.Systems
{
    public class SwitchMainMenuStateSystem : ISystem
    {
        private Filter _endMarkerFilter;
        private Filter _statePlayFilter;
        
        public World World { get; set; }

        public void OnAwake()
        {
            _endMarkerFilter = World.Filter
                .With<PlayEndMarker>()
                .Without<BlockMarker>();
            
            _statePlayFilter = World.Filter
                .With<StatePause>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var endMarkerEntity in _endMarkerFilter)
            {
                foreach (var statePlayEntity in _statePlayFilter)
                {
                    statePlayEntity.SetComponent(new StateMainMenu());
                    statePlayEntity.RemoveComponent<StatePause>();
                }
            }
        }

        public void Dispose()
        {
            _endMarkerFilter = null;
            _statePlayFilter = null;
        }
    }
}