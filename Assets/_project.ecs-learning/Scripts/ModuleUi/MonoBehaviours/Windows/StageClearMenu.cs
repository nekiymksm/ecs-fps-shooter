using _project.ecs_learning.Scripts.ModuleUi.SubModuleStageClearMenu.Components;
using Scellecs.Morpeh;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows
{
    public class StageClearMenu : Window
    {
        [SerializeField] private TextMeshProUGUI _stageId;
        [SerializeField] private TextMeshProUGUI _kills;
        [SerializeField] private TextMeshProUGUI _stagesCleared;
        
        [SerializeField] private Button _nextStage;
        [SerializeField] private Button _exitMainMenu;

        protected override void SetElements()
        {
            ref var stageClearComponent = ref WindowEntity.GetComponent<StageClearMenuComponent>();

            stageClearComponent.stageId = _stageId;
            stageClearComponent.kills = _kills;
            stageClearComponent.stagesCleared = _stagesCleared;
            
            AddButtonListener<NextStageButtonMarker>(_nextStage);
            AddButtonListener<ExitMainMenuButtonMarker>(_exitMainMenu);
        }
    }
}