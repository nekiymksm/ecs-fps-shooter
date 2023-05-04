using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Utilities;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleGameState.Systems
{
    public class SwitchWeaponMenuStateSystem : ISystem
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

                foreach (var stateEntity in _stateFilter)
                {
                    ref var stateComponent = ref stateEntity.GetComponent<StateComponent>();
                        
                    if (stateComponent.state == GameState.PlayGame && inputDataComponent.weaponButtonDowned)
                    { 
                        Set(StateSwitchAction.ShowWeapons);
                    }
                    else if (stateComponent.state == GameState.WeaponMenu && inputDataComponent.weaponButtonUpped)
                    {
                        Set(StateSwitchAction.Resume);
                    }
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