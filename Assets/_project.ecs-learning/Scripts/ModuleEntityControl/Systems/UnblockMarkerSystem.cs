using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleEntityControl.Systems
{
    public class UnblockMarkerSystem : ISystem
    {
        private Filter _filter;

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<BlockMarker>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                entity.SetComponent(new EntityCleanupMarker());
                entity.RemoveComponent<BlockMarker>();
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}