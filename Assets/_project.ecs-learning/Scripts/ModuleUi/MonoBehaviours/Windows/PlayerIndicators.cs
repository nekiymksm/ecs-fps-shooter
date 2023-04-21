using _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerIndicators.Components;
using Scellecs.Morpeh;
using TMPro;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows
{
    public class PlayerIndicators : Window
    {
        [SerializeField] private TextMeshProUGUI _enemiesCountText;

        protected override void SetElements()
        {
            WindowEntity.GetComponent<PlayerIndicatorsComponent>().enemiesCountText = _enemiesCountText;
        }
    }
}
