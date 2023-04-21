using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerIndicators.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerIndicators.Installer
{
    public class PlayerIndicatorsModuleExecutor : Executor
    {
        public PlayerIndicatorsModuleExecutor(World world,
            PlayerIndicatorsInitSystem playerIndicatorsInitSystem,
            PlayerIndicatorsShowSystem playerIndicatorsShowSystem,
            PlayerIndicatorsHideSystem playerIndicatorsHideSystem,
            EnemiesCountUpdateSystem enemiesCountUpdateSystem,
            EnemiesCountSetSystem enemiesCountSetSystem) : base(world)
        {
            InitializeSystems.AddInitializer(playerIndicatorsInitSystem);
            
            UpdateSystems.AddSystem(playerIndicatorsShowSystem);
            UpdateSystems.AddSystem(playerIndicatorsHideSystem);
            
            UpdateSystems.AddSystem(enemiesCountUpdateSystem);
            UpdateSystems.AddSystem(enemiesCountSetSystem);
        }
    }
}