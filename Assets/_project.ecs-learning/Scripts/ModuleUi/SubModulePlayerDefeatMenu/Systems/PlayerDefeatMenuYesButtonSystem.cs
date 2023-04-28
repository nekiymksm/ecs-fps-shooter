using _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerDefeatMenu.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerDefeatMenu.Systems
{
    public class PlayerDefeatMenuYesButtonSystem : ISystem
    {
        private Filter _filter;

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<PlayerDefeatMenuYesButtonMarker>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                entity.RemoveComponent<PlayerDefeatMenuYesButtonMarker>();
                Debug.LogError("YES");
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}