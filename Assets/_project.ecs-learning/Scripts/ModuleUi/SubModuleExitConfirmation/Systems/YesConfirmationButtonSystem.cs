using _project.ecs_learning.Scripts.ModuleGameState.Components;
using _project.ecs_learning.Scripts.ModuleGameState.Utilities;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows;
using _project.ecs_learning.Scripts.ModuleUi.SubModuleExitConfirmation.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModuleExitConfirmation.Systems
{
    public class YesConfirmationButtonSystem : ISystem
    {
        private Filter _filter;
        private UiRoot _uiRoot;

        public World World { get; set; }

        public YesConfirmationButtonSystem(UiRoot uiRoot)
        {
            _uiRoot = uiRoot;
        }

        public void OnAwake()
        {
            _filter = World.Filter.With<YesConfirmationButtonMarker>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                if (_uiRoot.GetWindow<MainMenu>().gameObject.activeSelf)
                {
                    Application.Quit();
                }
                else
                {
                    World.CreateEntity().SetComponent(new StateSwitchMarker {action = StateSwitchAction.End});
                }
                
                entity.RemoveComponent<YesConfirmationButtonMarker>();
                _uiRoot.GetWindow<ExitConfirmation>().gameObject.SetActive(false);
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}