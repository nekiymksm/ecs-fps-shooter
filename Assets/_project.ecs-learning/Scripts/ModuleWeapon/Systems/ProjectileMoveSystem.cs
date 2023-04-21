using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleWeapon.Configs;
using _project.ecs_learning.Scripts.ModuleWeapon.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleWeapon.Systems
{
    public class ProjectileMoveSystem : ISystem
    {
        private Filter _filter;
        private WeaponsCollection _weaponsCollection;

        public World World { get; set; }

        public ProjectileMoveSystem(WeaponsCollection weaponsCollection)
        {
            _weaponsCollection = weaponsCollection;
        }

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

                var weaponConfig = _weaponsCollection.GetConfig(projectile.weaponKind);
                var passedDistance = Vector3.Distance(moveMarker.startPosition, projectile.transform.position);
                
                projectile.transform
                    .Translate(Vector3.forward * weaponConfig.ProjectileMoveSpeed * deltaTime);
                
                if (passedDistance >= weaponConfig.ProjectileMaxMoveDistance)
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