using _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerDefeatMenu.Components;
using UnityEngine;
using UnityEngine.UI;

namespace _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows
{
    public class PlayerDefeatMenu : Window
    {
        [SerializeField] private Button _yes;
        [SerializeField] private Button _no;

        protected override void SetElements()
        {
            AddButtonListener<PlayerDefeatMenuYesButtonMarker>(_yes);
            AddButtonListener<PlayerDefeatMenuNoButtonMarker>(_no);
        }
    }
}