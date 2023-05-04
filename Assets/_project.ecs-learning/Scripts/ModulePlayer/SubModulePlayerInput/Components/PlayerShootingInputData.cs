using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerInput.Components
{
    [System.Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct PlayerShootingInputData : IComponent
    {
        public Entity weaponEntity;
        public float shootingStateValue; 
        public bool isTriggerReady;
    }
}