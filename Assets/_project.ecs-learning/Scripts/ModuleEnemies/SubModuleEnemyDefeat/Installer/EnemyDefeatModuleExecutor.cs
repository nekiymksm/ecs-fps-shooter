using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleEnemies.SubModuleEnemyDefeat.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleEnemies.SubModuleEnemyDefeat.Installer
{
    public class EnemyDefeatModuleExecutor : Executor
    {
        public EnemyDefeatModuleExecutor(World world,
            EnemyDefeatSystem enemyDefeatSystem) : base(world)
        {
            UpdateSystems.AddSystem(enemyDefeatSystem);
        }
    }
}