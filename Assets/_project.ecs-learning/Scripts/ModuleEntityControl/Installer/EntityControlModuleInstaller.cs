using _project.ecs_learning.Scripts.ModuleEntityControl.Systems;
using Zenject;

namespace _project.ecs_learning.Scripts.ModuleEntityControl.Installer
{
    public class EntityControlModuleInstaller : Installer<EntityControlModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<UnblockMarkerSystem>().AsSingle();
            Container.Bind<EntityCleanupSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<EntityControlModuleExecutor>().AsSingle();
        }
    }
}