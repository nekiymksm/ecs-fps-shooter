using System;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace _project.ecs_learning.Scripts.ModuleWeapon.Components
{
    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct ShotTriggerComponent : IComponent
    {
        public float lastShotTimeCounter;
    }
}