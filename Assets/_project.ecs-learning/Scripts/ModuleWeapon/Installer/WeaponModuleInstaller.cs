using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleWeapon.Configs;
using _project.ecs_learning.Scripts.ModuleWeapon.Systems;
using Zenject;

namespace _project.ecs_learning.Scripts.ModuleWeapon.Installer
{
    public class WeaponModuleInstaller : Installer<MainConfig, WeaponModuleInstaller>
    {
        private MainConfig _mainConfig;

        public WeaponModuleInstaller(MainConfig mainConfig)
        {
            _mainConfig = mainConfig;
        }
        
        public override void InstallBindings()
        {
            Container.Bind<WeaponsCollection>()
                .FromScriptableObject(_mainConfig.WeaponsCollection).AsSingle();

            Container.Bind<ShotSystem>().AsSingle();
            Container.Bind<ProjectileMoveSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<WeaponModuleExecutor>().AsSingle();
        }
    }
}