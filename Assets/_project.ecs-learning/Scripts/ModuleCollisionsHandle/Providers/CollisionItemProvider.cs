using _project.ecs_learning.Scripts.ModuleCollisionsHandle.Component;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleCollisionsHandle.Providers
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class CollisionItemProvider : MonoProvider<CollisionItemComponent>
    {
        private void OnCollisionEnter(Collision entry)
        {
            Entity.SetComponent(new CollisionData {entryCollision = entry});
        }
    }
}