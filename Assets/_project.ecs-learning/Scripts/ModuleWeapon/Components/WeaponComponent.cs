using _project.ecs_learning.Scripts.ModuleWeapon.Utilities;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleWeapon.Components
{
    [System.Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct WeaponComponent : IComponent
    {
        public WeaponKind kind;
        public Transform projectileStartPointTransform;
    }
}