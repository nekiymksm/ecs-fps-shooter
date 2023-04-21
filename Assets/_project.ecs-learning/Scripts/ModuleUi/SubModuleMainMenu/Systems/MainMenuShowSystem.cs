using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModuleMainMenu.Systems
{
    public class MainMenuShowSystem : ISystem
    {
        private Filter _showMarkerFilter;
        private Filter _endMarkerFilter;
        private UiRoot _uiRoot;

        public World World { get; set; }

        public MainMenuShowSystem(UiRoot uiRoot)
        {
            _uiRoot = uiRoot;
        }

        public void OnAwake()
        {
            _showMarkerFilter = World.Filter
                .With<MainMenuShowMarker>();
            
            _endMarkerFilter = World.Filter
                .With<PlayEndMarker>()
                .Without<BlockMarker>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _showMarkerFilter)
            {
                ShowMainMenu();
            }
            
            foreach (var entity in _endMarkerFilter)
            {
                ShowMainMenu();
            }
        }

        public void Dispose()
        {
            _showMarkerFilter = null;
        }

        private void ShowMainMenu()
        {
            _uiRoot.GetWindow<MainMenu>().gameObject.SetActive(true);
        }
    }
}