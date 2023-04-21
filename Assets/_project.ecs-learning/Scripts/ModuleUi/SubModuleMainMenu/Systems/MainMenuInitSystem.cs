using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows;
using _project.ecs_learning.Scripts.ModuleUi.SubModuleMainMenu.Components;
using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModuleMainMenu.Systems
{
    public class MainMenuInitSystem : IInitializer
    {
        private UiRoot _uiRoot;
        
        public World World { get; set; }
        
        public MainMenuInitSystem(UiRoot uiRoot)
        {
            _uiRoot = uiRoot;
        }
        
        public void OnAwake()
        {
            Entity entity = World.CreateEntity();
            entity.SetComponent(new MainMenuComponent());
            _uiRoot.GetWindow<MainMenu>().Init(entity);
            
            Entity markerEntity = World.CreateEntity();
            markerEntity.SetComponent(new MainMenuShowMarker());
            markerEntity.SetComponent(new EntityCleanupMarker());
        }

        public void Dispose()
        {
        }
    }
}