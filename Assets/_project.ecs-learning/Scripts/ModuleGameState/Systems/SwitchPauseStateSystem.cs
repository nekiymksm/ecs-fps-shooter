using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleGameState.Systems
{
    public class SwitchPauseStateSystem : ISystem
    {
        private Filter _inputDataFilter;
        private Filter _playStateFilter;
        private Filter _pauseStateFilter;
        
        public World World { get; set; }

        public void OnAwake()
        {
            _inputDataFilter = World.Filter.With<GameInputData>();
            _playStateFilter = World.Filter.With<StatePlay>();
            _pauseStateFilter = World.Filter.With<StatePause>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var inputDataEntity in _inputDataFilter)
            {
                ref var inputDataComponent = ref inputDataEntity.GetComponent<GameInputData>();

                if (inputDataComponent.cancelButtonValue != 0 && inputDataComponent.isCancelButtonReady)
                {
                    Entity entity = World.CreateEntity();
                    
                    foreach (var playStateEntity in _playStateFilter)
                    {
                        entity.SetComponent(new PlayPauseMarker());
                    }

                    foreach (var pauseStateEntity in _pauseStateFilter)
                    {
                        entity.SetComponent(new PlayResumeMarker());
                    }
                    
                    entity.SetComponent(new BlockMarker());
                    
                    inputDataComponent.isCancelButtonReady = false;
                }
            }
        }
        
        public void Dispose()
        {
            _inputDataFilter = null;
            _playStateFilter = null;
            _pauseStateFilter = null;
        }
    }
}