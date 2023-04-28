using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleWeapon.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleWeapon.Systems
{
    public class ProjectileMoveSystem : ISystem
    {
        private Filter _filter;

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter
                .With<ProjectileComponent>()
                .With<ProjectileMoveMarker>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var projectile = ref entity.GetComponent<ProjectileComponent>();
                ref var moveMarker = ref entity.GetComponent<ProjectileMoveMarker>();
                
                var passedDistance = Vector3.Distance(moveMarker.startPosition, projectile.transform.position);
                
                projectile.transform
                    .Translate(Vector3.forward * moveMarker.moveSpeed * deltaTime);
                
                if (passedDistance >= moveMarker.maxDistance)
                {
                    entity.SetComponent(new EntityCleanupMarker {itemToDestroyTransform = projectile.transform});
                }
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}