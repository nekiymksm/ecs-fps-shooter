using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Systems
{
    public class GameInputInitSystem : IInitializer
    {
        public World World { get; set; }
        
        public void OnAwake()
        {
            World.CreateEntity().SetComponent(new GameInputData());
        }

        public void Dispose()
        {
        }
    }
}