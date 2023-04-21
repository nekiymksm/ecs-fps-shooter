using _project.ecs_learning.Scripts.ModuleUi.SubModuleExitConfirmation.Components;
using UnityEngine;
using UnityEngine.UI;

namespace _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows
{
    public class ExitConfirmation : Window
    {
        [SerializeField] private Button _yes;
        [SerializeField] private Button _no;

        protected override void SetElements()
        {
            AddButtonListener<YesConfirmationButtonMarker>(_yes);
            AddButtonListener<NoConfirmationButtonMarker>(_no);
        }
    }
}