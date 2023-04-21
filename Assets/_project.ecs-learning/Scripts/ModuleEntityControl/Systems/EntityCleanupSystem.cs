using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleEntityControl.Systems
{
    public class EntityCleanupSystem : ILateSystem
    {
        private Filter _filter;
        
        public World World { get; set; }
        
        public void OnAwake()
        {
            _filter = World.Filter.With<EntityCleanupMarker>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var cleanupComponent = ref entity.GetComponent<EntityCleanupMarker>();

                if (cleanupComponent.itemToDestroyTransform != null)
                {
                    Object.Destroy(cleanupComponent.itemToDestroyTransform.gameObject);
                }
                
                World.RemoveEntity(entity);
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}