using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleEnemies.SubModuleEnemiesLoad.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleEnemies.SubModuleEnemiesLoad.Installer
{
    public class EnemiesLoadModuleExecutor : Executor
    {
        public EnemiesLoadModuleExecutor(World world,
            EnemiesLoadSystem enemiesLoadSystem,
            EnemiesCollapseSystem enemiesCollapseSystem) : base(world)
        {
            UpdateSystems.AddSystem(enemiesLoadSystem);
            UpdateSystems.AddSystem(enemiesCollapseSystem);
        }
    }
}