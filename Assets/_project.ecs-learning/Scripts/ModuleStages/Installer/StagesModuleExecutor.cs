using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleStages.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleStages.Installer
{
    public class StagesModuleExecutor : Executor
    {
        public StagesModuleExecutor(World world,
            StageLoadSystem stageLoadSystem,
            NextStageSystem nextStageSystem,
            ScoreIncreaseSystem scoreIncreaseSystem,
            ClearedStagesIncreaseSystem clearedStagesIncreaseSystem,
            StageDataClearSystem stageDataClearSystem) : base(world)
        {
            UpdateSystems.AddSystem(stageLoadSystem);
            UpdateSystems.AddSystem(nextStageSystem);
            UpdateSystems.AddSystem(scoreIncreaseSystem);
            UpdateSystems.AddSystem(clearedStagesIncreaseSystem);
            UpdateSystems.AddSystem(stageDataClearSystem);
        }
    }
}