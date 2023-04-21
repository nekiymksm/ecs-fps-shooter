using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleCamera.Configs;
using _project.ecs_learning.Scripts.ModuleCamera.Systems;
using Zenject;

namespace _project.ecs_learning.Scripts.ModuleCamera.Installer
{
    public class CameraModuleInstaller : Installer<MainConfig, CameraModuleInstaller>
    {
        private MainConfig _mainConfig;

        public CameraModuleInstaller(MainConfig mainConfig)
        {
            _mainConfig = mainConfig;
        }
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerCameraConfig>()
                .FromScriptableObject(_mainConfig.PlayerCameraConfig).AsSingle();

            Container.Bind<CameraLoadSystem>().AsSingle();
            Container.Bind<CameraCollapseSystem>().AsSingle();
            Container.Bind<CameraTrackSystem>().AsSingle();
            Container.Bind<CameraSightSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<CameraModuleExecutor>().AsSingle();
        }
    }
}