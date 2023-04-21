using System;
using Scellecs.Morpeh;
using TMPro;
using Unity.IL2CPP.CompilerServices;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerIndicators.Components
{
    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct PlayerIndicatorsComponent : IComponent
    {
        public TextMeshProUGUI enemiesCountText;
    }
}