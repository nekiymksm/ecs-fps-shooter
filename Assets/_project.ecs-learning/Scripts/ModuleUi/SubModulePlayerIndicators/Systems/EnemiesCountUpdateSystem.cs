using _project.ecs_learning.Scripts.ModuleEnemies.SubModuleEnemyDefeat.Components;
using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerIndicators.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerIndicators.Systems
{
    public class EnemiesCountUpdateSystem : ISystem
    {
        private Filter _defeatMarkerFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _defeatMarkerFilter = World.Filter
                .With<EnemyDefeatMarker>()
                .Without<BlockMarker>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var defeatMarkerEntity in _defeatMarkerFilter)
            {
                Entity entity = World.CreateEntity();
                entity.SetComponent(new EnemiesCountSetMarker());
                entity.SetComponent(new BlockMarker());
            }
        }

        public void Dispose()
        {
            _defeatMarkerFilter = null;
        }
    }
}