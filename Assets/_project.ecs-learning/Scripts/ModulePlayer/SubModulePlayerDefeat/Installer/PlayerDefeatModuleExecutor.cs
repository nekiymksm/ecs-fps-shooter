using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerDefeat.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerDefeat.Installer
{
    public class PlayerDefeatModuleExecutor : Executor
    {
        public PlayerDefeatModuleExecutor(World world,
            PlayerDefeatSystem playerDefeatSystem) : base(world)
        {
            UpdateSystems.AddSystem(playerDefeatSystem);
        }
    }
}