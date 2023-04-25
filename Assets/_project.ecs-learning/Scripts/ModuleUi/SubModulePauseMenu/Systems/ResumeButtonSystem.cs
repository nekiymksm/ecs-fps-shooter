using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Utilities;
using _project.ecs_learning.Scripts.ModuleUi.SubModulePauseMenu.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePauseMenu.Systems
{
    public class ResumeButtonSystem : ISystem
    {
        private Filter _buttonMarkerFilter;

        public World World { get; set; }
        
        public void OnAwake()
        {
            _buttonMarkerFilter = World.Filter.With<ResumeButtonMarker>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var buttonMarkerEntity in _buttonMarkerFilter)
            {
                buttonMarkerEntity.RemoveComponent<ResumeButtonMarker>();
                
                World.CreateEntity().SetComponent(new StateSwitchMarker {action = StateSwitchAction.Resume});
            }
        }
        
        public void Dispose()
        {
            _buttonMarkerFilter = null;
        }
    }
}