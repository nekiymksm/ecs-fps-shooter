using _project.ecs_learning.Scripts.ModuleCollisionsHandle.Component;
using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleWeapon.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleWeapon.Systems
{
    public class ProjectileCollisionDestroySystem : ISystem
    {
        private Filter _filter;

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter
                .With<ProjectileComponent>()
                .With<CollisionData>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var projectile = ref entity.GetComponent<ProjectileComponent>();
                entity.SetComponent(new EntityCleanupMarker {itemToDestroyTransform = projectile.transform});
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}