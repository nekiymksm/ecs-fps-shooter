using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Systems
{
    public class WeaponMenuInputSystem : ISystem
    {
        private Filter _gameInputFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _gameInputFilter = World.Filter.With<GameInputData>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var gameInputEntity in _gameInputFilter)
            {
                ref var gameInput = ref gameInputEntity.GetComponent<GameInputData>();

                gameInput.weaponButtonDowned = Input.GetKeyDown(KeyCode.Q);
                gameInput.weaponButtonUpped = Input.GetKeyUp(KeyCode.Q);
            }
        }

        public void Dispose()
        {
            _gameInputFilter = null;
        }
    }
}