using _project.ecs_learning.Scripts.ModuleUtilities.Systems;
using Zenject;

namespace _project.ecs_learning.Scripts.ModuleUtilities.Installer
{
    public class UtilitiesModuleInstaller : Installer<UtilitiesModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<CursorViewSystem>().AsSingle();
            Container.Bind<TimeScaleSwitchSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<UtilitiesModuleExecutor>().AsSingle();
        }
    }
}