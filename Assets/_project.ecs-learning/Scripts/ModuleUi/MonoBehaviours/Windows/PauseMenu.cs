using _project.ecs_learning.Scripts.ModuleUi.SubModulePauseMenu.Components;
using UnityEngine;
using UnityEngine.UI;

namespace _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows
{
    public class PauseMenu : Window
    {
        [SerializeField] private Button _resume;
        [SerializeField] private Button _restart;
        [SerializeField] private Button _settings;
        [SerializeField] private Button _exit;
        
        protected override void SetElements()
        {
            AddButtonListener<ResumeButtonMarker>(_resume);
            AddButtonListener<PauseMenuRestartButtonMarker>(_restart);
            AddButtonListener<ExitMainMenuButtonMarker>(_exit);
        }
    }
}