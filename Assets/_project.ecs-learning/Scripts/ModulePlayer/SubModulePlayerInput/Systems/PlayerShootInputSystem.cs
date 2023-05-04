using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Systems
{
    public class PlayerShootInputSystem : ISystem
    {
        private Filter _filter;
        
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<PlayerShootingInputData>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var inputData = ref entity.GetComponent<PlayerShootingInputData>();
                inputData.shootingStateValue = Input.GetAxisRaw("Fire1");
                
                if (inputData.shootingStateValue == 0)
                {
                    inputData.isTriggerReady = true;
                }
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}