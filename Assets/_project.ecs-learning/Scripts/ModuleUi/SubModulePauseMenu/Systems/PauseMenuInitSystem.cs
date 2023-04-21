using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows;
using _project.ecs_learning.Scripts.ModuleUi.SubModulePauseMenu.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePauseMenu.Systems
{
    public class PauseMenuInitSystem : IInitializer
    {
        private UiRoot _uiRoot;
        
        public World World { get; set; }

        public PauseMenuInitSystem(UiRoot uiRoot)
        {
            _uiRoot = uiRoot;
        }
        
        public void OnAwake()
        {
            Entity entity = World.CreateEntity();
            entity.SetComponent(new PauseMenuComponent());
            
            _uiRoot.GetWindow<PauseMenu>().Init(entity);
        }

        public void Dispose()
        {
        }
    }
}