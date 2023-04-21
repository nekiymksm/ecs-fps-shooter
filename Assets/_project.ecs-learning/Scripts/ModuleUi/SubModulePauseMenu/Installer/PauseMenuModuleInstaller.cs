using _project.ecs_learning.Scripts.ModuleUi.SubModulePauseMenu.Systems;
using Zenject;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePauseMenu.Installer
{
    public class PauseMenuModuleInstaller : Installer<PauseMenuModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<PauseMenuInitSystem>().AsSingle();
            
            Container.Bind<ResumeButtonSystem>().AsSingle();
            Container.Bind<ExitMainMenuButtonSystem>().AsSingle();
            Container.Bind<PauseMenuShowSystem>().AsSingle();
            Container.Bind<PauseMenuHideSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<PauseMenuModuleExecutor>().AsSingle();
        }
    }
}