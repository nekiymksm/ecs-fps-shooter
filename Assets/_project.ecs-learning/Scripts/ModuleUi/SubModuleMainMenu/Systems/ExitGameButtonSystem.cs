using _project.ecs_learning.Scripts.ModuleUi.SubModuleExitConfirmation.Components;
using _project.ecs_learning.Scripts.ModuleUi.SubModuleMainMenu.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModuleMainMenu.Systems
{
    public class ExitGameButtonSystem : ISystem
    {
        private Filter _filter;

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<ExitGameButtonMarker>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                entity.RemoveComponent<ExitGameButtonMarker>();
                World.CreateEntity().SetComponent(new ExitConfirmationShowMarker());
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}