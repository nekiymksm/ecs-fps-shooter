using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleStages.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleStages.Installer
{
    public class StagesModuleExecutor : Executor
    {
        public StagesModuleExecutor(World world,
            StageLoadSystem stageLoadSystem,
            ScoreIncreaseSystem scoreIncreaseSystem) : base(world)
        {
            UpdateSystems.AddSystem(stageLoadSystem);
            UpdateSystems.AddSystem(scoreIncreaseSystem);
        }
    }
}