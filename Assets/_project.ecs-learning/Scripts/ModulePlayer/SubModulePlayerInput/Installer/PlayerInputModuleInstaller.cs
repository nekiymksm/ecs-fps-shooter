using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Systems;
using Zenject;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Installer
{
    public class PlayerInputModuleInstaller : Installer<PlayerInputModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameInputInitSystem>().AsSingle();
            
            Container.Bind<CancelInputSystem>().AsSingle();
            Container.Bind<PlayerMovementInputSystem>().AsSingle();
            Container.Bind<PlayerShootInputSystem>().AsSingle();
            Container.Bind<WeaponMenuInputSystem>().AsSingle();
            
            Container.Bind<PlayerInputBlockSystem>().AsSingle();
            Container.Bind<PlayerInputUnblockSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<PlayerInputModuleExecutor>().AsSingle();
        }
    }
}