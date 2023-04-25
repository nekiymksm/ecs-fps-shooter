using _project.ecs_learning.Scripts.ModuleUi.SubModuleStageClearMenu.Systems;
using Zenject;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModuleStageClearMenu.Installer
{
    public class StageClearMenuModuleInstaller : Installer<StageClearMenuModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<StageClearMenuInitSystem>().AsSingle();

            Container.Bind<StageClearMenuShowSystem>().AsSingle();
            Container.Bind<StageClearMenuInfoSetSystem>().AsSingle();
            Container.Bind<StageClearMenuHideSystem>().AsSingle();

            Container.Bind<StageClearMenuNextButtonSystem>().AsSingle();
            Container.Bind<StageClearMenuMainButtonSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<StageClearMenuExecutor>().AsSingle();
        }
    }
}