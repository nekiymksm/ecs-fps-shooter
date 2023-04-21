using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Systems
{
    public class PlayerMovementInputSystem : ISystem
    {
        private Filter _filter;
        
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<PlayerMovementInputData>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var dataComponent = ref entity.GetComponent<PlayerMovementInputData>();

                dataComponent.sightHorizontalDirectionValue = Input.GetAxis("Mouse X");
                dataComponent.sightVerticalDirectionValue = Input.GetAxis("Mouse Y");
                
                dataComponent.walkHorizontalValue = Input.GetAxis("Horizontal");
                dataComponent.walkVerticalValue = Input.GetAxis("Vertical");
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}