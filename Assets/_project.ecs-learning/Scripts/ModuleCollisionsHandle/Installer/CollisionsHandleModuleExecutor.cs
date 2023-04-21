using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleCollisionsHandle.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleCollisionsHandle.Installer
{
    public class CollisionsHandleModuleExecutor : Executor
    {
        public CollisionsHandleModuleExecutor(World world,
            CollisionsDataCleanupSystem collisionsDataCleanupSystem) : base(world)
        {
            LateUpdateSystems.AddSystem(collisionsDataCleanupSystem);
        }
    }
}