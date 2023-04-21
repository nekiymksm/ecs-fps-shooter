using _project.ecs_learning.Scripts.ModuleUi.SubModuleMainMenu.Systems;
using Zenject;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModuleMainMenu.Installer
{
    public class MainMenuModuleInstaller : Installer<MainMenuModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<MainMenuInitSystem>().AsSingle();

            Container.Bind<MainMenuShowSystem>().AsSingle();
            Container.Bind<NewGameButtonSystem>().AsSingle();
            Container.Bind<ExitGameButtonSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<MainMenuModuleExecutor>().AsSingle();
        }
    }
}