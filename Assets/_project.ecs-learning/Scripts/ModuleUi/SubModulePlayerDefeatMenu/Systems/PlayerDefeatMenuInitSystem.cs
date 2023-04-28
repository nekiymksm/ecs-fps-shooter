using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows;
using _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerDefeatMenu.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerDefeatMenu.Systems
{
    public class PlayerDefeatMenuInitSystem : IInitializer
    {
        private UiRoot _uiRoot;
        
        public World World { get; set; }
        
        public PlayerDefeatMenuInitSystem(UiRoot uiRoot)
        {
            _uiRoot = uiRoot;
        }

        public void OnAwake()
        {
            Entity entity = World.CreateEntity();
            entity.SetComponent(new PlayerDefeatMenuComponent());
            
            _uiRoot.GetWindow<PlayerDefeatMenu>().Init(entity);
        }

        public void Dispose()
        {
        }
    }
}