using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerMovement.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerMovement.Installer
{
    public class PlayerMovementModuleExecutor : Executor
    {
        public PlayerMovementModuleExecutor(World world,
            PlayerWalkSystem playerWalkSystem,
            PlayerRotationSystem playerRotationSystem) : base(world)
        {
            UpdateSystems.AddSystem(playerWalkSystem);
            UpdateSystems.AddSystem(playerRotationSystem);
        }
    }
}