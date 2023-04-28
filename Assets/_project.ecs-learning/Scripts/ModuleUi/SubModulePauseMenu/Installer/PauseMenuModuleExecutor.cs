using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleUi.SubModulePauseMenu.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePauseMenu.Installer
{
    public class PauseMenuModuleExecutor : Executor
    {
        public PauseMenuModuleExecutor(World world,
            PauseMenuInitSystem pauseMenuInitSystem,
            ResumeButtonSystem resumeButtonSystem,
            PauseMenuRestartButtonSystem pauseMenuRestartButtonSystem,
            ExitMainMenuButtonSystem exitMainMenuButtonSystem,
            PauseMenuShowSystem pauseMenuShowSystem,
            PauseMenuHideSystem pauseMenuHideSystem) : base(world)
        {
            InitializeSystems.AddInitializer(pauseMenuInitSystem);
            
            UpdateSystems.AddSystem(resumeButtonSystem);
            UpdateSystems.AddSystem(pauseMenuRestartButtonSystem);
            UpdateSystems.AddSystem(exitMainMenuButtonSystem);
            UpdateSystems.AddSystem(pauseMenuShowSystem);
            UpdateSystems.AddSystem(pauseMenuHideSystem);
        }
    }
}