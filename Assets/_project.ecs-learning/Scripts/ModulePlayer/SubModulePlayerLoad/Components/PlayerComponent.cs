using _project.ecs_learning.Scripts.ModuleWeapon.Providers;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerLoad.Components
{
    [System.Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct PlayerComponent : IComponent
    {
        public Transform transform;
        public Transform cameraTrackingPointTransform;
        public CharacterController characterController;
        public WeaponProvider weapon;
    }
}