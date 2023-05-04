using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Components;
using _project.ecs_learning.Scripts.ModuleWeapon.Components;
using _project.ecs_learning.Scripts.ModuleWeapon.Configs;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleWeapon.Systems
{
    public class ShotTriggerSystem : ISystem
    {
        private Filter _inputDataFilter;
        private WeaponsCollection _weaponsCollection;

        public World World { get; set; }
        
        public ShotTriggerSystem(WeaponsCollection weaponsCollection)
        {
            _weaponsCollection = weaponsCollection;
        }

        public void OnAwake()
        {
            _inputDataFilter = World.Filter.With<PlayerShootingInputData>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var inputDataEntity in _inputDataFilter)
            {
                ref var inputData = ref inputDataEntity.GetComponent<PlayerShootingInputData>();
                ref var shotTimer = ref inputData.weaponEntity.GetComponent<ShotTriggerComponent>();

                shotTimer.lastShotTimeCounter += deltaTime;

                if (inputData.shootingStateValue != 0 && inputData.isTriggerReady)
                {
                    ref var weapon = ref inputData.weaponEntity.GetComponent<WeaponComponent>();
                    var weaponConfig = _weaponsCollection.GetConfig(weapon.kind);
                    
                    if (shotTimer.lastShotTimeCounter >= weaponConfig.RateOfShoot)
                    {
                        inputData.weaponEntity.SetComponent(new ShotMarker());
                        
                        shotTimer.lastShotTimeCounter = 0;
                        inputData.isTriggerReady = weaponConfig.IsAutomatic;
                    }
                }
            }
        }

        public void Dispose()
        {
            _inputDataFilter = null;
        }
    }
}