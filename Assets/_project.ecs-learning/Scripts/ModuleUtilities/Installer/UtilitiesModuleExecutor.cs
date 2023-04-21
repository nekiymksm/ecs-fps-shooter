using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleUtilities.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUtilities.Installer
{
    public class UtilitiesModuleExecutor : Executor
    {
        public UtilitiesModuleExecutor(World world,
            CursorViewSystem cursorViewSystem,
            TimeScaleSwitchSystem timeScaleSwitchSystem) : base(world)
        {
            UpdateSystems.AddSystem(cursorViewSystem);
            UpdateSystems.AddSystem(timeScaleSwitchSystem);
        }
    }
}