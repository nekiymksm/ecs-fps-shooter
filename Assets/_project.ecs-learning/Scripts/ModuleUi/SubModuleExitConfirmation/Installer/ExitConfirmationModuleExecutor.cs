using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleUi.SubModuleExitConfirmation.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModuleExitConfirmation.Installer
{
    public class ExitConfirmationModuleExecutor : Executor
    {
        public ExitConfirmationModuleExecutor(World world,
            ExitConfirmationInitSystem exitConfirmationInitSystem,
            ExitConfirmationShowSystem exitConfirmationShowSystem,
            YesConfirmationButtonSystem yesConfirmationButtonSystem,
            NoConfirmationButtonSystem noConfirmationButtonSystem) : base(world)
        {
            InitializeSystems.AddInitializer(exitConfirmationInitSystem);

            UpdateSystems.AddSystem(exitConfirmationShowSystem);
            UpdateSystems.AddSystem(yesConfirmationButtonSystem);
            UpdateSystems.AddSystem(noConfirmationButtonSystem);
        }
    }
}