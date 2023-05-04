using _project.ecs_learning.Scripts.ModuleEntityControl.Components;
using _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerIndicators.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerIndicators.Systems
{
    public class WeaponIndicatorSetSystem : ISystem
    {
        private Filter _setMarkerFilter;
        private Filter _playerIndicatorsFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _setMarkerFilter = World.Filter
                .With<WeaponIndicatorSetMarker>()
                .Without<BlockMarker>();

            _playerIndicatorsFilter = World.Filter
                .With<PlayerIndicatorsComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var setMarkerEntity in _setMarkerFilter)
            {
                foreach (var playerIndicatorsEntity in _playerIndicatorsFilter)
                {
                    ref var setMarker = ref setMarkerEntity.GetComponent<WeaponIndicatorSetMarker>();
                    ref var playerIndicators = ref playerIndicatorsEntity.GetComponent<PlayerIndicatorsComponent>();
                    
                    for (int i = 0; i < playerIndicators.weaponIndicatorsTexts.Length; i++)
                    {
                        playerIndicators.weaponIndicatorsTexts[i].gameObject.SetActive(i == (int)setMarker.kind);
                    }
                }
            }
        }

        public void Dispose()
        {
            _setMarkerFilter = null;
            _playerIndicatorsFilter = null;
        }
    }
}