using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleMaps.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleMaps.Installer
{
    public class MapsModuleExecutor : Executor
    {
        public MapsModuleExecutor(World world,
            MapLoadSystem mapLoadSystem,
            MapCollapseSystem mapCollapseSystem) : base(world)
        {
            UpdateSystems.AddSystem(mapLoadSystem);
            UpdateSystems.AddSystem(mapCollapseSystem);
        }
    }
}