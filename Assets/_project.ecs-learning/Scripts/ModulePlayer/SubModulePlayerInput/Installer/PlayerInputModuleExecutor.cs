using _project.ecs_learning.Scripts.MainInstaller;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Systems;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Installer
{
    public class PlayerInputModuleExecutor : Executor
    {
        public PlayerInputModuleExecutor(World world,
            GameInputInitSystem gameInputInitSystem,
            CancelInputSystem cancelInputSystem,
            PlayerMovementInputSystem playerMovementInputSystem,
            PlayerShootInputSystem playerShootInputSystem,
            WeaponMenuInputSystem weaponMenuInputSystem,
            PlayerInputBlockSystem playerInputBlockSystem,
            PlayerInputUnblockSystem playerInputUnblockSystem) : base(world)
        {
            InitializeSystems.AddInitializer(gameInputInitSystem);
            
            UpdateSystems.AddSystem(cancelInputSystem);
            UpdateSystems.AddSystem(playerMovementInputSystem);
            UpdateSystems.AddSystem(playerShootInputSystem);
            UpdateSystems.AddSystem(weaponMenuInputSystem);
            
            UpdateSystems.AddSystem(playerInputBlockSystem);
            UpdateSystems.AddSystem(playerInputUnblockSystem);
        }
    }
}