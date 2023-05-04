using System;
using _project.ecs_learning.Scripts.ModuleWeapon.Utilities;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModulePlayerIndicators.Components
{
    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct WeaponIndicatorSetMarker : IComponent
    {
        public WeaponKind kind;
    }
}