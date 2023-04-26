using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleEnemies.SubModuleEnemiesLoad.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleEnemies.SubModuleEnemiesLoad.Installer
{
    public class EnemiesLoadModuleExecutor : Executor
    {
        public EnemiesLoadModuleExecutor(World world,
            EnemiesCollapseSystem enemiesCollapseSystem,
            EnemiesLoadSystem enemiesLoadSystem) : base(world)
        {
            UpdateSystems.AddSystem(enemiesCollapseSystem);
            UpdateSystems.AddSystem(enemiesLoadSystem);
        }
    }
}