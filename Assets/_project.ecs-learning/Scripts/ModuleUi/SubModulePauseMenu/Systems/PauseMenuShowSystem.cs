using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePauseMenu.Systems
{
    public class PauseMenuShowSystem : ISystem
    {
        private Filter _gameStateFilter;
        private UiRoot _uiRoot;

        public World World { get; set; }

        public PauseMenuShowSystem(UiRoot uiRoot)
        {
            _uiRoot = uiRoot;
        }
        
        public void OnAwake()
        {
            _gameStateFilter = World.Filter
                .With<PlayPauseMarker>()
                .Without<BlockMarker>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var gameStateEntity in _gameStateFilter)
            {
                _uiRoot.GetWindow<PauseMenu>().gameObject.SetActive(true);
            }
        }
        
        public void Dispose()
        {
            _gameStateFilter = null;
        }
    }
}