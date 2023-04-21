using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleUi.SubModuleStageClearMenu.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModuleStageClearMenu.Installer
{
    public class StageClearMenuExecutor : Executor
    {
        public StageClearMenuExecutor(World world,
            StageClearMenuInitSystem stageClearMenuInitSystem,
            StageClearMenuShowSystem stageClearMenuShowSystem,
            ClearedStageInfoSetSystem clearedStageInfoSetSystem,
            StageClearMenuNextButtonSystem stageClearMenuNextButtonSystem,
            StageClearMenuMainButtonSystem stageClearMenuMainButtonSystem) : base(world)
        {
            InitializeSystems.AddInitializer(stageClearMenuInitSystem);

            UpdateSystems.AddSystem(stageClearMenuShowSystem);
            UpdateSystems.AddSystem(clearedStageInfoSetSystem);

            UpdateSystems.AddSystem(stageClearMenuNextButtonSystem);
            UpdateSystems.AddSystem(stageClearMenuMainButtonSystem);
        }
    }
}