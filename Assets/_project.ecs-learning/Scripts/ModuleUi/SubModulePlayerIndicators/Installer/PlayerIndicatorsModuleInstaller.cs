using _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerIndicators.Systems;
using Zenject;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerIndicators.Installer
{
    public class PlayerIndicatorsModuleInstaller : Installer<PlayerIndicatorsModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerIndicatorsInitSystem>().AsSingle();
            
            Container.Bind<PlayerIndicatorsShowSystem>().AsSingle();
            Container.Bind<PlayerIndicatorsHideSystem>().AsSingle();
            
            Container.Bind<EnemiesCountUpdateSystem>().AsSingle();
            Container.Bind<EnemiesCountSetSystem>().AsSingle();

            Container.Bind<ClearedStagesIndicatorUpdateSystem>().AsSingle();
            Container.Bind<ClearedStagesIndicatorSetSystem>().AsSingle();

            Container.Bind<WeaponIndicatorSetSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<PlayerIndicatorsModuleExecutor>().AsSingle();
        }
    }
}