using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows;
using _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerIndicators.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerIndicators.Systems
{
    public class PlayerIndicatorsInitSystem : IInitializer
    {
        private UiRoot _uiRoot;
        
        public World World { get; set; }

        public PlayerIndicatorsInitSystem(UiRoot uiRoot)
        {
            _uiRoot = uiRoot;
        }

        public void OnAwake()
        {
            Entity entity = World.CreateEntity();
            entity.SetComponent(new PlayerIndicatorsComponent());
            
            _uiRoot.GetWindow<PlayerIndicators>().Init(entity);
        }

        public void Dispose()
        {
        }
    }
}