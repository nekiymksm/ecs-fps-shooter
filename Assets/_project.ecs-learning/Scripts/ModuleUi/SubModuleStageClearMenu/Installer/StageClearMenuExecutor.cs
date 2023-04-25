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
            StageClearMenuInfoSetSystem stageClearMenuInfoSetSystem,
            StageClearMenuHideSystem stageClearMenuHideSystem,
            StageClearMenuNextButtonSystem stageClearMenuNextButtonSystem,
            StageClearMenuMainButtonSystem stageClearMenuMainButtonSystem) : base(world)
        {
            InitializeSystems.AddInitializer(stageClearMenuInitSystem);

            UpdateSystems.AddSystem(stageClearMenuShowSystem);
            UpdateSystems.AddSystem(stageClearMenuInfoSetSystem);
            UpdateSystems.AddSystem(stageClearMenuHideSystem);

            UpdateSystems.AddSystem(stageClearMenuNextButtonSystem);
            UpdateSystems.AddSystem(stageClearMenuMainButtonSystem);
        }
    }
}