using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerMovement.Systems;
using Zenject;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerMovement.Installer
{
    public class PlayerMovementModuleInstaller : Installer<PlayerMovementModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerWalkSystem>().AsSingle();
            Container.Bind<PlayerRotationSystem>().AsSingle();
            Container.Bind<TeleportPlayerSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<PlayerMovementModuleExecutor>().AsSingle();
        }
    }
}