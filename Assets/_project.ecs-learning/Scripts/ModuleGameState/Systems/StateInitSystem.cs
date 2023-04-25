using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Utilities;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleGameState.Systems
{
    public class StateInitSystem : IInitializer
    {
        public World World { get; set; }

        public void OnAwake()
        {
            World.CreateEntity().SetComponent(new StateComponent());
            World.CreateEntity().SetComponent(new StateSwitchMarker {action = StateSwitchAction.Init});
        }

        public void Dispose()
        {
        }
    }
}