using _project.ecs_learning.Scripts.ModuleEnemies.SubModuleEnemyDefeat.Systems;
using Zenject;

namespace _project.ecs_learning.Scripts.ModuleEnemies.SubModuleEnemyDefeat.Installer
{
    public class EnemyDefeatModuleInstaller : Installer<EnemyDefeatModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<EnemyDefeatSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<EnemyDefeatModuleExecutor>().AsSingle();
        }
    }
}