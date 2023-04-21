using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleUi.SubModuleMainMenu.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModuleMainMenu.Installer
{
    public class MainMenuModuleExecutor : Executor
    {
        public MainMenuModuleExecutor(World world,
            MainMenuInitSystem mainMenuInitSystem,
            MainMenuShowSystem mainMenuShowSystem,
            NewGameButtonSystem newGameButtonSystem,
            ExitGameButtonSystem exitGameButtonSystem) : base(world)
        {
            InitializeSystems.AddInitializer(mainMenuInitSystem);

            UpdateSystems.AddSystem(mainMenuShowSystem);
            UpdateSystems.AddSystem(newGameButtonSystem);
            UpdateSystems.AddSystem(exitGameButtonSystem);
        }
    }
}