using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleCamera.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleCamera.Installer
{
    public class CameraModuleExecutor : Executor
    {
        public CameraModuleExecutor(World world,
            CameraLoadSystem cameraLoadSystem,
            CameraCollapseSystem cameraCollapseSystem,
            CameraTrackSystem cameraTrackSystem,
            CameraSightSystem cameraSightSystem) : base(world)
        {
            UpdateSystems.AddSystem(cameraLoadSystem);
            UpdateSystems.AddSystem(cameraCollapseSystem);
            UpdateSystems.AddSystem(cameraTrackSystem);
            UpdateSystems.AddSystem(cameraSightSystem);
        }
    }
}