using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Utilities;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows;
using _project.ecs_learning.Scripts.ModuleUi.SubModuleStageClearMenu.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModuleStageClearMenu.Systems
{
    public class StageClearMenuNextButtonSystem : ISystem
    {
        private Filter _filter;
        private UiRoot _uiRoot;

        public World World { get; set; }
        
        public StageClearMenuNextButtonSystem(UiRoot uiRoot)
        {
            _uiRoot = uiRoot;
        }

        public void OnAwake()
        {
            _filter = World.Filter.With<NextStageButtonMarker>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                entity.RemoveComponent<NextStageButtonMarker>();
                
                _uiRoot.GetWindow<StageClearMenu>().gameObject.SetActive(false);
                
                World.CreateEntity().SetComponent(new StateSwitchMarker {action = StateSwitchAction.Next});
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}