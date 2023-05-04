using _project.ecs_learning.Scripts.ModuleGameState.Systems;
using Zenject;

namespace _project.ecs_learning.Scripts.ModuleGameState.Installer
{
    public class GameStateModuleInstaller : Installer<GameStateModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<StateInitSystem>().AsSingle();
            
            Container.Bind<SwitchPauseStateSystem>().AsSingle();
            Container.Bind<SwitchWeaponMenuStateSystem>().AsSingle();
            Container.Bind<StateSwitchSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<GameStateModuleExecutor>().AsSingle();
        }
    }
}