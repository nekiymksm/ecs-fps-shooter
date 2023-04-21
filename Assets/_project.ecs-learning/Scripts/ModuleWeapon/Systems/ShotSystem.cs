using _project.ecs_learning.Scripts.ModuleCamera.Components;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Components;
using _project.ecs_learning.Scripts.ModuleWeapon.Components;
using _project.ecs_learning.Scripts.ModuleWeapon.Configs;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleWeapon.Systems
{
    public class ShotSystem : ISystem
    {
        private Filter _inputDataFilter;
        private Filter _cameraFilter;
        private WeaponsCollection _weaponsCollection;

        public World World { get; set; }
        
        public ShotSystem(WeaponsCollection weaponsCollection)
        {
            _weaponsCollection = weaponsCollection;
        }

        public void OnAwake()
        {
            _inputDataFilter = World.Filter.With<PlayerShootingInputData>();
            _cameraFilter = World.Filter.With<CameraComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var inputDataEntity in _inputDataFilter)
            {
                ref var inputData = ref inputDataEntity.GetComponent<PlayerShootingInputData>();
                    
                if (inputData.shootingStateValue != 0 && inputData.isWeaponReady)
                {
                    ref var weapon = ref inputData.weaponEntity.GetComponent<WeaponComponent>();
                    var weaponConfig = _weaponsCollection.GetConfig(weapon.kind);
                    
                    foreach (var cameraEntity in _cameraFilter)
                    {
                        ref var camera = ref cameraEntity.GetComponent<CameraComponent>();
                        
                        var startPosition = weapon.projectileStartPointTransform.position;
                        var projectile = Object.Instantiate(
                            weaponConfig.ProjectilePrefab, startPosition, camera.transform.rotation);

                        projectile.Entity
                            .SetComponent(new ProjectileMoveMarker {startPosition = startPosition});
                    }
                    
                    inputData.isWeaponReady = weaponConfig.IsAutomatic;
                }
            }
        }

        public void Dispose()
        {
            _inputDataFilter = null;
            _cameraFilter = null;
        }
    }
}