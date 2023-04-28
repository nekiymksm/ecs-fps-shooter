using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerDefeatMenu.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerDefeatMenu.Installer
{
    public class PlayerDefeatMenuModuleExecutor : Executor
    {
        public PlayerDefeatMenuModuleExecutor(World world,
            PlayerDefeatMenuInitSystem playerDefeatMenuInitSystem,
            PlayerDefeatMenuShowSystem playerDefeatMenuShowSystem,
            PlayerDefeatMenuYesButtonSystem playerDefeatMenuYesButtonSystem,
            PlayerDefeatMenuNoButtonSystem playerDefeatMenuNoButtonSystem) : base(world)
        {
            InitializeSystems.AddInitializer(playerDefeatMenuInitSystem);

            UpdateSystems.AddSystem(playerDefeatMenuShowSystem);
            UpdateSystems.AddSystem(playerDefeatMenuYesButtonSystem);
            UpdateSystems.AddSystem(playerDefeatMenuNoButtonSystem);
        }
    }
}