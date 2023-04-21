using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleGameState.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleGameState.Installer
{
    public class GameStateModuleExecutor : Executor
    {
        public GameStateModuleExecutor(World world,
            StateInitSystem stateInitSystem,
            SwitchPlayStateSystem switchPlayStateSystem,
            SwitchPauseStateSystem switchPauseStateSystem,
            SwitchMainMenuStateSystem switchMainMenuStateSystem,
            StateStageClearSwitchSystem stateStageClearSwitchSystem,
            PlayPauseSystem playPauseSystem,
            PlayResumeSystem playResumeSystem) : base(world)
        {
            InitializeSystems.AddInitializer(stateInitSystem);

            UpdateSystems.AddSystem(switchPlayStateSystem);
            UpdateSystems.AddSystem(switchPauseStateSystem);
            UpdateSystems.AddSystem(switchMainMenuStateSystem);
            UpdateSystems.AddSystem(stateStageClearSwitchSystem);
            
            UpdateSystems.AddSystem(playPauseSystem);
            UpdateSystems.AddSystem(playResumeSystem);
        }
    }
}