using _project.ecs_learning.Scripts.ModuleCollisionsHandle.Systems;
using Zenject;

namespace _project.ecs_learning.Scripts.ModuleCollisionsHandle.Installer
{
    public class CollisionsHandleModuleInstaller : Installer<CollisionsHandleModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<CollisionsDataCleanupSystem>().AsSingle();
            Container.Bind<TriggersDataCleanupSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<CollisionsHandleModuleExecutor>().AsSingle();
        }
    }
}