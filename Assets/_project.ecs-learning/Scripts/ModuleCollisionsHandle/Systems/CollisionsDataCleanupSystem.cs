using _project.ecs_learning.Scripts.ModuleCollisionsHandle.Component;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleCollisionsHandle.Systems
{
    public class CollisionsDataCleanupSystem : ILateSystem
    {
        private Filter _filter;
        
        public World World { get; set; }
        
        public void OnAwake()
        {
            _filter = World.Filter.With<CollisionData>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                entity.RemoveComponent<CollisionData>();
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}