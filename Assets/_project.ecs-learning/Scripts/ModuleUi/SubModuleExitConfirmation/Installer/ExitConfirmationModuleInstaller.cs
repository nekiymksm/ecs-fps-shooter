using _project.ecs_learning.Scripts.ModuleUi.SubModuleExitConfirmation.Systems;
using Zenject;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModuleExitConfirmation.Installer
{
    public class ExitConfirmationModuleInstaller : Installer<ExitConfirmationModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ExitConfirmationInitSystem>().AsSingle();

            Container.Bind<ExitConfirmationShowSystem>().AsSingle();
            Container.Bind<YesConfirmationButtonSystem>().AsSingle();
            Container.Bind<NoConfirmationButtonSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<ExitConfirmationModuleExecutor>().AsSingle();
        }
    }
}