using _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerIndicators.Components;
using Scellecs.Morpeh;
using TMPro;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows
{
    public class PlayerIndicators : Window
    {
        [SerializeField] private TextMeshProUGUI _enemiesCountText;
        [SerializeField] private TextMeshProUGUI _clearStagesText;
        [SerializeField] private TextMeshProUGUI[] _weaponIndicatorsTexts;

        protected override void SetElements()
        {
            ref var indicators = ref WindowEntity.GetComponent<PlayerIndicatorsComponent>();
            
            indicators.enemiesCountText = _enemiesCountText;
            indicators.clearStagesText = _clearStagesText;
            indicators.weaponIndicatorsTexts = _weaponIndicatorsTexts;
        }
    }
}