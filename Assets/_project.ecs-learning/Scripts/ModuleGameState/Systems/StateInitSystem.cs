using _project.ecs_learning.Scripts.ModuleGameState.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleGameState.Systems
{
    public class StateInitSystem : IInitializer
    {
        public World World { get; set; }

        public void OnAwake()
        {
            World.CreateEntity().SetComponent(new StateMainMenu());
        }

        public void Dispose()
        {
        }
    }
}