using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleStages.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleGameState.Systems
{
    public class StateStageClearSwitchSystem : ISystem
    {
        private Filter _stageClearFilter;
        private Filter _statePlayFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _stageClearFilter = World.Filter
                .With<StageClearMarker>()
                .Without<BlockMarker>();
            
            _statePlayFilter = World.Filter
                .With<StatePlay>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var stageClearEntity in _stageClearFilter)
            {
                foreach (var statePlayEntity in _statePlayFilter)
                {
                    statePlayEntity.SetComponent(new StateStageClear());
                    statePlayEntity.RemoveComponent<StatePlay>();
                }
            }
        }

        public void Dispose()
        {
            _stageClearFilter = null;
            _statePlayFilter = null;
        }
    }
}