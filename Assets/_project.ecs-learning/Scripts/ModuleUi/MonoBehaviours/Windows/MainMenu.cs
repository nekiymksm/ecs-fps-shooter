using _project.ecs_learning.Scripts.ModuleUi.SubModuleMainMenu.Components;
using UnityEngine;
using UnityEngine.UI;

namespace _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows
{
    public class MainMenu : Window
    {
        [SerializeField] private Button _newGame;
        [SerializeField] private Button _settings;
        [SerializeField] private Button _exit;

        protected override void SetElements()
        {
            AddButtonListener<NewGameButtonMarker>(_newGame);
            AddButtonListener<ExitGameButtonMarker>(_exit);
        }
    }
}