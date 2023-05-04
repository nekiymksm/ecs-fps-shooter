using _project.ecs_learning.Scripts.ModuleUi.SubModuleWeaponMenu.Systems;
using Zenject;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModuleWeaponMenu.Installer
{
    public class WeaponMenuModuleInstaller : Installer<WeaponMenuModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<WeaponMenuInitSystem>().AsSingle();

            Container.Bind<WeaponMenuShowSystem>().AsSingle();
            Container.Bind<WeaponMenuHideSystem>().AsSingle();
            
            Container.Bind<WeaponMenuPistolButtonSystem>().AsSingle();
            Container.Bind<WeaponMenuSmgButtonSystem>().AsSingle();
            Container.Bind<WeaponMenuShotgunButtonSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<WeaponMenuModuleExecutor>().AsSingle();
        }
    }
}