using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Utilities;
using _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerIndicators.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerIndicators.Systems
{
    public class ClearedStagesIndicatorUpdateSystem : ISystem
    {
        private Filter _switchMarkerFilter;

        public World World { get; set; }


        public void OnAwake()
        {
            _switchMarkerFilter = World.Filter
                .With<StateSwitchMarker>()
                .With<EntityCleanupMarker>()
                .Without<BlockMarker>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _switchMarkerFilter)
            {
                ref var switchMarker = ref entity.GetComponent<StateSwitchMarker>();

                if (switchMarker.action is StateSwitchAction.Start or StateSwitchAction.Next)
                {
                    World.CreateEntity().SetComponent(new ClearedStagesIndicatorSetMarker());
                }
            }
        }
        
        public void Dispose()
        {
            _switchMarkerFilter = null;
        }
    }
}