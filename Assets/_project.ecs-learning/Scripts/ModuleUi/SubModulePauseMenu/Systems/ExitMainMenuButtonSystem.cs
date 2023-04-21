using _project.ecs_learning.Scripts.ModuleUi.SubModuleExitConfirmation.Components;
using _project.ecs_learning.Scripts.ModuleUi.SubModulePauseMenu.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePauseMenu.Systems
{
    public class ExitMainMenuButtonSystem : ISystem
    {
        private Filter _filter;

        public World World { get; set; }

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