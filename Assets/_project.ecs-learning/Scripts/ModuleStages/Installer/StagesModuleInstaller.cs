using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleStages.Configs;
using _project.ecs_learning.Scripts.ModuleStages.Systems;
using Zenject;

namespace _project.ecs_learning.Scripts.ModuleStages.Installer
{
    public class StagesModuleInstaller : Installer<MainConfig, StagesModuleInstaller>
    {
        private MainConfig _mainConfig;

        public StagesModuleInstaller(MainConfig mainConfig)
        {
            _mainConfig = mainConfig;
        }
        
        public override void InstallBindings()
        {
            Container.Bind<StageInfosCollection>().FromScriptableObject(_mainConfig.StageInfosCollection).AsSingle();

            Container.Bind<StageLoadSystem>().AsSingle();
            Container.Bind<NextStageSystem>().AsSingle();
            Container.Bind<ScoreIncreaseSystem>().AsSingle();
            Container.Bind<ClearedStagesIncreaseSystem>().AsSingle();
            Container.Bind<StageDataClearSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<StagesModuleExecutor>().AsSingle();
        }
    }
}