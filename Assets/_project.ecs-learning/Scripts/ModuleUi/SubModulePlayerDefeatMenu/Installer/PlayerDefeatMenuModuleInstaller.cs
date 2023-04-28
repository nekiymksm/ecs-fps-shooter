using _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerDefeatMenu.Systems;
using Zenject;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerDefeatMenu.Installer
{
    public class PlayerDefeatMenuModuleInstaller : Installer<PlayerDefeatMenuModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerDefeatMenuInitSystem>().AsSingle();

            Container.Bind<PlayerDefeatMenuShowSystem>().AsSingle();
            Container.Bind<PlayerDefeatMenuYesButtonSystem>().AsSingle();
            Container.Bind<PlayerDefeatMenuNoButtonSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<PlayerDefeatMenuModuleExecutor>().AsSingle();
        }
    }
}