using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows;
using _project.ecs_learning.Scripts.ModuleUi.SubModuleExitConfirmation.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModuleExitConfirmation.Systems
{
    public class ExitConfirmationInitSystem : IInitializer
    {
        private UiRoot _uiRoot;
        
        public World World { get; set; }

        public ExitConfirmationInitSystem(UiRoot uiRoot)
        {
            _uiRoot = uiRoot;
        }

        public void OnAwake()
        {
            Entity entity = World.CreateEntity();
            entity.SetComponent(new ExitConfirmationComponent());
            
            _uiRoot.GetWindow<ExitConfirmation>().Init(entity);
        }

        public void Dispose()
        {
        }
    }
}