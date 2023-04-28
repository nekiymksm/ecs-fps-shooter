using _project.ecs_learning.Scripts.ModuleCollisionsHandle.Component;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleCollisionsHandle.Systems
{
    public class TriggersDataCleanupSystem : ILateSystem
    {
        private Filter _filter;
        
        public World World { get; set; }
        
        public void OnAwake()
        {
            _filter = World.Filter.With<TriggerData>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                entity.RemoveComponent<TriggerData>();
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}