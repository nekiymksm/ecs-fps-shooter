using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Utilities;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerLoad.Components;
using _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerIndicators.Components;
using _project.ecs_learning.Scripts.ModuleUi.SubModuleWeaponMenu.Components;
using _project.ecs_learning.Scripts.ModuleWeapon.Components;
using _project.ecs_learning.Scripts.ModuleWeapon.Utilities;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModuleWeaponMenu.Systems
{
    public class WeaponMenuShotgunButtonSystem : ISystem
    {
        private Filter _buttonMarkerFilter;
        private Filter _playerFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _buttonMarkerFilter = World.Filter.With<WeaponMenuShotgunButtonMarker>();
            _playerFilter = World.Filter.With<PlayerComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _buttonMarkerFilter)
            {
                entity.RemoveComponent<WeaponMenuShotgunButtonMarker>();
                
                foreach (var playerEntity in _playerFilter)
                {
                    playerEntity.SetComponent(new SetWeaponMarker {kind = WeaponKind.Shotgun});
                    
                    World.CreateEntity().SetComponent(new StateSwitchMarker {action = StateSwitchAction.Resume});

                    Entity markerEntity = World.CreateEntity();
                    markerEntity.SetComponent(new WeaponIndicatorSetMarker {kind = WeaponKind.Shotgun});
                    markerEntity.SetComponent(new BlockMarker());
                }
            }
        }

        public void Dispose()
        {
            _buttonMarkerFilter = null;
            _playerFilter = null;
        }
    }
}