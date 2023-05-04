using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleUi.SubModuleWeaponMenu.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModuleWeaponMenu.Installer
{
    public class WeaponMenuModuleExecutor : Executor
    {
        public WeaponMenuModuleExecutor(World world,
            WeaponMenuInitSystem weaponMenuInitSystem,
            WeaponMenuShowSystem weaponMenuShowSystem,
            WeaponMenuHideSystem weaponMenuHideSystem,
            WeaponMenuPistolButtonSystem weaponMenuPistolButtonSystem,
            WeaponMenuSmgButtonSystem weaponMenuSmgButtonSystem,
            WeaponMenuShotgunButtonSystem weaponMenuShotgunButtonSystem) : base(world)
        {
            InitializeSystems.AddInitializer(weaponMenuInitSystem);

            UpdateSystems.AddSystem(weaponMenuShowSystem);
            UpdateSystems.AddSystem(weaponMenuHideSystem);
            
            UpdateSystems.AddSystem(weaponMenuPistolButtonSystem);
            UpdateSystems.AddSystem(weaponMenuSmgButtonSystem);
            UpdateSystems.AddSystem(weaponMenuShotgunButtonSystem);
        }
    }
}