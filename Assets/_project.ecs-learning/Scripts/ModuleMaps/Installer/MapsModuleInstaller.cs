using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleMaps.Configs;
using _project.ecs_learning.Scripts.ModuleMaps.Systems;
using Zenject;

namespace _project.ecs_learning.Scripts.ModuleMaps.Installer
{
    public class MapsModuleInstaller : Installer<MainConfig, MapsModuleInstaller>
    {
        private MainConfig _mainConfig;

        public MapsModuleInstaller(MainConfig mainConfig)
        {
            _mainConfig = mainConfig;
        }
        
        public override void InstallBindings()
        {
            Container.Bind<MapsCollection>()
                .FromScriptableObject(_mainConfig.MapsCollection).AsSingle();
            
            Container.Bind<MapCollapseSystem>().AsSingle();
            Container.Bind<MapLoadSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<MapsModuleExecutor>().AsSingle();
        }
    }
}