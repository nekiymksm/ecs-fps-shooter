using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Utilities;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows;
using _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerDefeatMenu.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerDefeatMenu.Systems
{
    public class PlayerDefeatMenuNoButtonSystem : ISystem
    {
        private Filter _filter;
        private UiRoot _uiRoot;

        public World World { get; set; }

        public PlayerDefeatMenuNoButtonSystem(UiRoot uiRoot)
        {
            _uiRoot = uiRoot;
        }

        public void OnAwake()
        {
            _filter = World.Filter.With<PlayerDefeatMenuNoButtonMarker>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                entity.RemoveComponent<PlayerDefeatMenuNoButtonMarker>();
                
                World.CreateEntity().SetComponent(new StateSwitchMarker {action = StateSwitchAction.End});
                
                _uiRoot.GetWindow<PlayerDefeatMenu>().gameObject.SetActive(false);
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}