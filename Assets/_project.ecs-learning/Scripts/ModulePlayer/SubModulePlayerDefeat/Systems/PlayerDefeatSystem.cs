using _project.ecs_learning.Scripts.ModuleCollisionsHandle.Component;
using _project.ecs_learning.Scripts.ModuleEnemies.SubModuleEnemiesLoad.Providers;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerLoad.Components;
using _project.ecs_learning.Scripts.ModuleWeapon.Providers;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerDefeat.Systems
{
    public class PlayerDefeatSystem : ISystem
    {
        private Filter _filter;

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter
                .With<PlayerComponent>()
                .With<TriggerData>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var player = ref entity.GetComponent<PlayerComponent>();
                ref var triggerData = ref entity.GetComponent<TriggerData>();
                
                if (triggerData.collider.TryGetComponent(out EnemyProvider enemy) || 
                    triggerData.collider.TryGetComponent(out ProjectileProvider projectile))
                {
                    Debug.LogError("POTRACHENO");
                }
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}