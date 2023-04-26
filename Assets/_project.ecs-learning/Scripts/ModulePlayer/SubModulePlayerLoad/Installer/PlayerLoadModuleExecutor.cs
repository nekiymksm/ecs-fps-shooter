using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerLoad.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerLoad.Installer
{
    public class PlayerLoadModuleExecutor : Executor
    {
        public PlayerLoadModuleExecutor(World world,
            PlayerLoadStartSystem playerLoadStartSystem,
            PlayerLoadViewSystem playerLoadViewSystem,
            PlayerLoadCameraTrackSystem playerLoadCameraTrackSystem,
            PlayerLoadMovementDataSystem playerLoadMovementDataSystem,
            PlayerLoadShootingDataSystem playerLoadShootingDataSystem,
            PlayerLoadEndSystem playerLoadEndSystem,
            PlayerSetOnSpawnPointSystem playerSetOnSpawnPointSystem,
            PlayerCollapseSystem playerCollapseSystem) : base(world)
        {
            UpdateSystems.AddSystem(playerLoadStartSystem);
            UpdateSystems.AddSystem(playerLoadViewSystem);
            UpdateSystems.AddSystem(playerLoadCameraTrackSystem);
            UpdateSystems.AddSystem(playerLoadMovementDataSystem);
            UpdateSystems.AddSystem(playerLoadShootingDataSystem);
            UpdateSystems.AddSystem(playerLoadEndSystem);

            UpdateSystems.AddSystem(playerSetOnSpawnPointSystem);
            UpdateSystems.AddSystem(playerCollapseSystem);
        }
    }
}