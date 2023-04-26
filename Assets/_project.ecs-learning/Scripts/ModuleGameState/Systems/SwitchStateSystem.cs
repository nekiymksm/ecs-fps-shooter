using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Utilities;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleGameState.Systems
{
    public class StateSwitchSystem : ISystem
    {
        private Filter _switchMarkerFilter;
        private Filter _stateFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _switchMarkerFilter = World.Filter
                .With<StateSwitchMarker>()
                .Without<EntityCleanupMarker>()
                .Without<BlockMarker>();
            
            _stateFilter = World.Filter
                .With<StateComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var switchMarkerEntity in _switchMarkerFilter)
            {
                ref var switchMarker = ref switchMarkerEntity.GetComponent<StateSwitchMarker>();
                
                switch (switchMarker.action)
                {
                    case StateSwitchAction.Init:
                        Set(GameState.MainMenu);
                        break;
                    case StateSwitchAction.Start:
                        Set(GameState.Play);
                        switchMarkerEntity.SetComponent(new PlayStartMarker());
                        break;
                    case StateSwitchAction.Pause:
                        Set(GameState.Pause);
                        switchMarkerEntity.SetComponent(new PlayPauseMarker());
                        break;
                    case StateSwitchAction.Resume:
                        Set(GameState.Play);
                        switchMarkerEntity.SetComponent(new PlayResumeMarker());
                        break;
                    case StateSwitchAction.Result:
                        Set(GameState.StageClear);
                        switchMarkerEntity.SetComponent(new PlayClearMarker());
                        break;
                    case StateSwitchAction.Next:
                        Set(GameState.Play);
                        switchMarkerEntity.SetComponent(new PlayNextMarker());
                        break;
                    case StateSwitchAction.End:
                        Set(GameState.MainMenu);
                        switchMarkerEntity.SetComponent(new PlayEndMarker());
                        break;
                }

                switchMarkerEntity.SetComponent(new BlockMarker());
            }
        }

        public void Dispose()
        {
            _switchMarkerFilter = null;
            _stateFilter = null;
        }

        private void Set(GameState newState)
        {
            foreach (var stateEntity in _stateFilter)
            {
                ref var stateComponent = ref stateEntity.GetComponent<StateComponent>();
                stateComponent.state = newState;
            }
        }
    }
}