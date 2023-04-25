using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Utilities;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows;
using _project.ecs_learning.Scripts.ModuleUi.SubModuleMainMenu.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModuleMainMenu.Systems
{
    public class NewGameButtonSystem : ISystem
    {
        private Filter _buttonMarkerFilter;
        private UiRoot _uiRoot;

        public World World { get; set; }

        public NewGameButtonSystem(UiRoot uiRoot)
        {
            _uiRoot = uiRoot;
        }

        public void OnAwake()
        {
            _buttonMarkerFilter = World.Filter.With<NewGameButtonMarker>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var buttonMarkerEntity in _buttonMarkerFilter)
            {
                buttonMarkerEntity.RemoveComponent<NewGameButtonMarker>();

                _uiRoot.GetWindow<MainMenu>().gameObject.SetActive(false);

                World.CreateEntity().SetComponent(new StateSwitchMarker {action = StateSwitchAction.Start});
            }
        }

        public void Dispose()
        {
            _buttonMarkerFilter = null;
        }
    }
}