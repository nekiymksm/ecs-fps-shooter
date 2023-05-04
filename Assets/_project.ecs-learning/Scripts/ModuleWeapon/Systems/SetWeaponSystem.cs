using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerLoad.Components;
using _project.ecs_learning.Scripts.ModuleWeapon.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleWeapon.Systems
{
    public class SetWeaponSystem : ISystem
    {
        private Filter _filter;

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter
                .With<PlayerComponent>()
                .With<SetWeaponMarker>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var player = ref entity.GetComponent<PlayerComponent>();
                ref var weaponMarker = ref entity.GetComponent<SetWeaponMarker>();

                player.weapon.Entity.GetComponent<WeaponComponent>().kind = weaponMarker.kind;
                
                entity.RemoveComponent<SetWeaponMarker>();
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}