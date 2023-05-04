using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours;
using _project.ecs_learning.Scripts.ModuleUi.SubModuleExitConfirmation.Installer;
using _project.ecs_learning.Scripts.ModuleUi.SubModuleMainMenu.Installer;
using _project.ecs_learning.Scripts.ModuleUi.SubModulePauseMenu.Installer;
using _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerDefeatMenu.Installer;
using _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerIndicators.Installer;
using _project.ecs_learning.Scripts.ModuleUi.SubModuleStageClearMenu.Installer;
using _project.ecs_learning.Scripts.ModuleUi.SubModuleWeaponMenu.Installer;
using Zenject;

namespace _project.ecs_learning.Scripts.ModuleUi.Installer
{
    public class UiModuleInstaller : Installer<MainConfig, UiModuleInstaller>
    {
        private MainConfig _mainConfig;
        
        public UiModuleInstaller(MainConfig mainConfig)
        {
            _mainConfig = mainConfig;
        }
        
        public override void InstallBindings()
        {
            Container.Bind<UiRoot>().FromComponentInNewPrefab(_mainConfig.UiRootPrefab).AsSingle().NonLazy();

            ExitConfirmationModuleInstaller.Install(Container);
            MainMenuModuleInstaller.Install(Container);
            PauseMenuModuleInstaller.Install(Container);
            PlayerIndicatorsModuleInstaller.Install(Container);
            StageClearMenuModuleInstaller.Install(Container);
            PlayerDefeatMenuModuleInstaller.Install(Container);
            WeaponMenuModuleInstaller.Install(Container);
        }
    }
}