using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Components;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerLoad.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerLoad.Systems
{
    public class PlayerLoadMovementDataSystem : ISystem
    {
        private Filter _filter;
        
        public World World { get; set; }
        
        public void OnAwake()
        {
            _filter = World.Filter.With<PlayerLoadMarker>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                entity.SetComponent(new PlayerMovementInputData());
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}