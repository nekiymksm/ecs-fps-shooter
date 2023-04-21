using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows;
using _project.ecs_learning.Scripts.ModuleUi.SubModuleStageClearMenu.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModuleStageClearMenu.Systems
{
    public class StageClearMenuInitSystem : IInitializer
    {
        private UiRoot _uiRoot;
        
        public World World { get; set; }
        
        public StageClearMenuInitSystem(UiRoot uiRoot)
        {
            _uiRoot = uiRoot;
        }

        public void OnAwake()
        {
            Entity entity = World.CreateEntity();
            entity.SetComponent(new StageClearMenuComponent());
            
            _uiRoot.GetWindow<StageClearMenu>().Init(entity);
        }

        public void Dispose()
        {
        }
    }
}