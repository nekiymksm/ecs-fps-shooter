using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Utilities;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows;
using _project.ecs_learning.Scripts.ModuleUi.SubModulePauseMenu.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePauseMenu.Systems
{
    public class PauseMenuRestartButtonSystem : ISystem
    {
        private Filter _filter;
        private UiRoot _uiRoot;

        public World World { get; set; }

        public PauseMenuRestartButtonSystem(UiRoot uiRoot)
        {
            _uiRoot = uiRoot;
        }

        public void OnAwake()
        {
            _filter = World.Filter.With<PauseMenuRestartButtonMarker>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                entity.RemoveComponent<PauseMenuRestartButtonMarker>();
                
                World.CreateEntity().SetComponent(new StateSwitchMarker {action = StateSwitchAction.Restart});
                
                _uiRoot.GetWindow<PauseMenu>().gameObject.SetActive(false);
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}