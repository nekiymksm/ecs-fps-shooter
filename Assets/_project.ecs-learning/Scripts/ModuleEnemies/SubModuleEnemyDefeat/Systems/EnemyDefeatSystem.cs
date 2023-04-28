using _project.ecs_learning.Scripts.ModuleCollisionsHandle.Component;
using _project.ecs_learning.Scripts.ModuleEnemies.SubModuleEnemiesLoad.Components;
using _project.ecs_learning.Scripts.ModuleEnemies.SubModuleEnemyDefeat.Components;
using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleWeapon.Providers;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleEnemies.SubModuleEnemyDefeat.Systems
{
    public class EnemyDefeatSystem : ISystem
    {
        private Filter _filter;

        public World World { get; set; }
        
        public void OnAwake()
        {
            _filter = World.Filter
                .With<EnemyComponent>()
                .With<CollisionData>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var enemyComponent = ref entity.GetComponent<EnemyComponent>();
                ref var collisionData = ref entity.GetComponent<CollisionData>();

                if (collisionData.collision.collider.TryGetComponent(out ProjectileProvider projectile))
                {
                    entity.SetComponent(new EntityCleanupMarker {itemToDestroyTransform = enemyComponent.transform});

                    Entity markerEntity = World.CreateEntity();
                    markerEntity.SetComponent(new EnemyDefeatMarker());
                    markerEntity.SetComponent(new BlockMarker());
                }
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}