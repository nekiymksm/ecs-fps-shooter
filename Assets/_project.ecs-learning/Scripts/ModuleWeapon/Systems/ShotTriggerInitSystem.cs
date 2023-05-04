using _project.ecs_learning.Scripts.ModuleWeapon.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleWeapon.Systems
{
    public class ShotTriggerInitSystem : ISystem
    {
        private Filter _filter;

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter
                .With<WeaponComponent>()
                .Without<ShotTriggerComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                entity.SetComponent(new ShotTriggerComponent());
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}