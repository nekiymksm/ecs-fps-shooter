using _project.ecs_learning.Scripts.ModuleCamera.Components;
using _project.ecs_learning.Scripts.ModuleWeapon.Components;
using _project.ecs_learning.Scripts.ModuleWeapon.Configs;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleWeapon.Systems
{
    public class ShotSystem : ISystem
    {
        private Filter _filter;
        private Filter _cameraFilter;
        private WeaponsCollection _weaponsCollection;

        public World World { get; set; }

        public ShotSystem(WeaponsCollection weaponsCollection)
        {
            _weaponsCollection = weaponsCollection;
        }

        public void OnAwake()
        {
            _filter = World.Filter
                .With<WeaponComponent>()
                .With<ShotMarker>();
            
            _cameraFilter = World.Filter
                .With<CameraComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                entity.RemoveComponent<ShotMarker>();
                
                foreach (var cameraEntity in _cameraFilter)
                {
                    ref var weapon = ref entity.GetComponent<WeaponComponent>();
                    ref var camera = ref cameraEntity.GetComponent<CameraComponent>();
                        
                    var weaponConfig = _weaponsCollection.GetConfig(weapon.kind);
                    var startPosition = weapon.projectileStartPointTransform.position;
                    var projectile = Object.Instantiate(
                        weaponConfig.ProjectilePrefab, startPosition, camera.transform.rotation);

                    projectile.Entity
                        .SetComponent(new ProjectileMoveMarker
                        {
                            moveSpeed = weaponConfig.ProjectileMoveSpeed,
                            maxDistance = weaponConfig.ProjectileMaxMoveDistance,
                            startPosition = startPosition
                        });
                }
            }
        }

        public void Dispose()
        {
            _filter = null;
            _cameraFilter = null;
        }
    }
}