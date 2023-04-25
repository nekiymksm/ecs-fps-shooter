using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours;
using _project.ecs_learning.Scripts.ModuleUi.SubModuleExitConfirmation.Components;
using _project.ecs_learning.Scripts.ModuleUi.SubModuleStageClearMenu.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModuleStageClearMenu.Systems
{
    public class StageClearMenuMainButtonSystem : ISystem
    {
        private Filter _filter;
        private UiRoot _uiRoot;

        public World World { get; set; }
        
        public StageClearMenuMainButtonSystem(UiRoot uiRoot)
        {
            _uiRoot = uiRoot;
        }

        public void OnAwake()
        {
            _filter = World.Filter.With<ExitMainMenuButtonMarker>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                entity.RemoveComponent<ExitMainMenuButtonMarker>();

                World.CreateEntity().SetComponent(new ExitConfirmationShowMarker());
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}