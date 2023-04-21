using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePauseMenu.Systems
{
    public class PauseMenuHideSystem : ISystem
    {
        private Filter _resumeMarkerFilter;
        private Filter _endMarkerFilter;
        private UiRoot _uiRoot;

        public World World { get; set; }

        public PauseMenuHideSystem(UiRoot uiRoot)
        {
            _uiRoot = uiRoot;
        }
        
        public void OnAwake()
        {
            _resumeMarkerFilter = World.Filter
                .With<PlayResumeMarker>()
                .Without<BlockMarker>();
            
            _endMarkerFilter = World.Filter
                .With<PlayEndMarker>()
                .Without<BlockMarker>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var resumeMarkerEntity in _resumeMarkerFilter)
            {
                DisablePauseMenu();
            }
            
            foreach (var endMarkerEntity in _endMarkerFilter)
            {
                DisablePauseMenu();
            }
        }
        
        public void Dispose()
        {
            _resumeMarkerFilter = null;
            _endMarkerFilter = null;
        }

        private void DisablePauseMenu()
        {
            _uiRoot.GetWindow<PauseMenu>().gameObject.SetActive(false);
        }
    }
}