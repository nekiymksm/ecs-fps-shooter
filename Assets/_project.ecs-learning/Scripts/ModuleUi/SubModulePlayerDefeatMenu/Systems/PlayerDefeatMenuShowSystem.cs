using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerDefeatMenu.Systems
{
    public class PlayerDefeatMenuShowSystem : ISystem
    {
        private Filter _filter;
        private UiRoot _uiRoot;

        public World World { get; set; }
        
        public PlayerDefeatMenuShowSystem(UiRoot uiRoot)
        {
            _uiRoot = uiRoot;
        }

        public void OnAwake()
        {
            _filter = World.Filter
                .With<PlayDefeatMarker>()
                .Without<BlockMarker>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                _uiRoot.GetWindow<PlayerDefeatMenu>().gameObject.SetActive(true);
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}