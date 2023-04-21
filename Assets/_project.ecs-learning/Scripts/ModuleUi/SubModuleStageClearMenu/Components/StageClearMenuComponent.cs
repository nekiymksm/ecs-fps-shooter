using System;
using Scellecs.Morpeh;
using TMPro;
using Unity.IL2CPP.CompilerServices;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModuleStageClearMenu.Components
{
    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct StageClearMenuComponent : IComponent
    {
        public TextMeshProUGUI stageId;
        public TextMeshProUGUI kills;
        public TextMeshProUGUI stagesCleared;
    }
}