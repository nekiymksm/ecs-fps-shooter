using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Utilities;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerIndicators.Systems
{
    public class PlayerIndicatorsShowSystem : ISystem
    {
        private Filter _switchMarkerFilter;
        private UiRoot _uiRoot;
        
        public World World { get; set; }

        public PlayerIndicatorsShowSystem(UiRoot uiRoot)
        {
            _uiRoot = uiRoot;
        }

        public void OnAwake()
        {
            _switchMarkerFilter = World.Filter
                .With<StateSwitchMarker>()
                .With<EntityCleanupMarker>()
                .Without<BlockMarker>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _switchMarkerFilter)
            {
                ref var switchMarker = ref entity.GetComponent<StateSwitchMarker>();

                if (switchMarker.action is StateSwitchAction.Start or StateSwitchAction.Next)
                {
                    _uiRoot.GetWindow<PlayerIndicators>().gameObject.SetActive(true);
                }
            }
        }
        
        public void Dispose()
        {
            _switchMarkerFilter = null;
        }
    }
}