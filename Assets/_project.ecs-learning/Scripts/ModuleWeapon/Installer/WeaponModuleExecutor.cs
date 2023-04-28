using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModuleWeapon.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleWeapon.Installer
{
    public class WeaponModuleExecutor : Executor
    {
        public WeaponModuleExecutor(World world,
            ShotSystem shotSystem,
            ProjectileMoveSystem projectileMoveSystem,
            ProjectileCollisionDestroySystem projectileCollisionDestroySystem) : base(world)
        {
            UpdateSystems.AddSystem(shotSystem);
            UpdateSystems.AddSystem(projectileMoveSystem);
            UpdateSystems.AddSystem(projectileCollisionDestroySystem);
        }
    }
}