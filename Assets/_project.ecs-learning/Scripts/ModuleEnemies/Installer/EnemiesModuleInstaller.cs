using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleEnemies.Configs;
using _project.ecs_learning.Scripts.ModuleEnemies.SubModuleEnemiesLoad.Installer;
using _project.ecs_learning.Scripts.ModuleEnemies.SubModuleEnemyDefeat.Installer;
using Zenject;

namespace _project.ecs_learning.Scripts.ModuleEnemies.Installer
{
    public class EnemiesModuleInstaller : Installer<MainConfig, EnemiesModuleInstaller>
    {
        private MainConfig _mainConfig;

        public EnemiesModuleInstaller(MainConfig mainConfig)
        {
            _mainConfig = mainConfig;
        }
        
        public override void InstallBindings()
        {
            Container.Bind<EnemiesCollection>().FromScriptableObject(_mainConfig.EnemiesCollection).AsSingle();
            
            EnemiesLoadModuleInstaller.Install(Container);
            EnemyDefeatModuleInstaller.Install(Container);
        }
    }
}