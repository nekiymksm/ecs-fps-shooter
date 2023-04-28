using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModulePlayer.Configs;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerDefeat.Installer;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerLoad.Installer;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Installer;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerMovement.Installer;
using Zenject;

namespace _project.ecs_learning.Scripts.ModulePlayer.Installer
{
    public class PlayerModuleInstaller : Installer<MainConfig, PlayerModuleInstaller>
    {
        private MainConfig _mainConfig;

        public PlayerModuleInstaller(MainConfig mainConfig)
        {
            _mainConfig = mainConfig;
        }
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerViewsCollection>().FromScriptableObject(_mainConfig.PlayerViewsCollection).AsSingle();
            Container.Bind<PlayerMovementConfig>().FromScriptableObject(_mainConfig.PlayerMovementConfig).AsSingle();
            
            PlayerLoadModuleInstaller.Install(Container);
            PlayerInputModuleInstaller.Install(Container);
            PlayerMovementModuleInstaller.Install(Container);
            PlayerDefeatModuleInstaller.Install(Container);
        }
    }
}