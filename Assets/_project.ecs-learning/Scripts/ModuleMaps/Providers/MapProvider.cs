using _project.ecs_learning.Scripts.ModuleMaps.Components;
using Scellecs.Morpeh.Providers;
using Unity.IL2CPP.CompilerServices;

namespace _project.ecs_learning.Scripts.ModuleMaps.Providers
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class MapProvider : MonoProvider<MapComponent> 
    {
    }
}