using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Systems
{
    public class CancelInputSystem : ISystem
    {
        private Filter _filter;

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<GameInputData>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var inputDataComponent = ref entity.GetComponent<GameInputData>();
                inputDataComponent.cancelButtonValue = Input.GetAxisRaw("Cancel");
                
                if(inputDataComponent.cancelButtonValue == 0)
                {
                    inputDataComponent.isCancelButtonReady = true;
                }
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}