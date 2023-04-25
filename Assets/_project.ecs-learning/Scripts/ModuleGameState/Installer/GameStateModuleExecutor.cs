using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleGameState.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleGameState.Installer
{
    public class GameStateModuleExecutor : Executor
    {
        public GameStateModuleExecutor(World world,
            StateInitSystem stateInitSystem,
            SwitchPauseStateSystem switchPauseStateSystem,
            StateSwitchSystem stateSwitchSystem) : base(world)
        {
            InitializeSystems.AddInitializer(stateInitSystem);
            
            UpdateSystems.AddSystem(switchPauseStateSystem);
            UpdateSystems.AddSystem(stateSwitchSystem);
        }
    }
}