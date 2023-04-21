using _project.ecs_learning.Scripts.ModuleGameState.Systems;
using Zenject;

namespace _project.ecs_learning.Scripts.ModuleGameState.Installer
{
    public class GameStateModuleInstaller : Installer<GameStateModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<StateInitSystem>().AsSingle();

            Container.Bind<SwitchPlayStateSystem>().AsSingle();
            Container.Bind<SwitchPauseStateSystem>().AsSingle();
            Container.Bind<SwitchMainMenuStateSystem>().AsSingle();
            Container.Bind<StateStageClearSwitchSystem>().AsSingle();
            
            Container.Bind<PlayPauseSystem>().AsSingle();
            Container.Bind<PlayResumeSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<GameStateModuleExecutor>().AsSingle();
        }
    }
}