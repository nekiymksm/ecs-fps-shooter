using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleMaps.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleMaps.Installer
{
    public class MapsModuleExecutor : Executor
    {
        public MapsModuleExecutor(World world,
            MapCollapseSystem mapCollapseSystem,
            MapLoadSystem mapLoadSystem) : base(world)
        {
            UpdateSystems.AddSystem(mapCollapseSystem);
            UpdateSystems.AddSystem(mapLoadSystem);
        }
    }
}