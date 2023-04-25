using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Utilities;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleGameState.Systems
{
    public class SwitchPauseStateSystem : ISystem
    {
        private Filter _inputDataFilter;
        private Filter _stateFilter;
        
        public World World { get; set; }

        public void OnAwake()
        {
            _inputDataFilter = World.Filter.With<GameInputData>();
            _stateFilter = World.Filter.With<StateComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var inputDataEntity in _inputDataFilter)
            {
                ref var inputDataComponent = ref inputDataEntity.GetComponent<GameInputData>();
                
                if (inputDataComponent.cancelButtonValue != 0 && inputDataComponent.isCancelButtonReady)
                {
                    foreach (var stateEntity in _stateFilter)
                    {
                        ref var stateComponent = ref stateEntity.GetComponent<StateComponent>();
                        
                        switch (stateComponent.state)
                        {
                            case GameState.Play:
                                Set(StateSwitchAction.Pause);
                                break;
                            case GameState.Pause:
                                Set(StateSwitchAction.Resume);
                                break;
                        }
                    }

                    inputDataComponent.isCancelButtonReady = false;
                }
            }
        }
        
        public void Dispose()
        {
            _inputDataFilter = null;
            _stateFilter = null;
        }

        private void Set(StateSwitchAction switchAction)
        {
            World.CreateEntity().SetComponent(new StateSwitchMarker {action = switchAction});
        }
    }
}