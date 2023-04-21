using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleEntityControl.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleEntityControl.Installer
{
    public class EntityControlModuleExecutor : Executor
    {
        public EntityControlModuleExecutor(World world,
            UnblockMarkerSystem unblockMarkerSystem,
            EntityCleanupSystem entityCleanupSystem) : base(world)
        {
            UpdateSystems.AddSystem(unblockMarkerSystem);
            LateUpdateSystems.AddSystem(entityCleanupSystem);
        }
    }
}