using _project.ecs_learning.Scripts.ModuleWeapon.Components;
using Scellecs.Morpeh.Providers;
using Unity.IL2CPP.CompilerServices;

namespace _project.ecs_learning.Scripts.ModuleWeapon.Providers
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class ProjectileProvider : MonoProvider<ProjectileComponent> 
    {
    }
}