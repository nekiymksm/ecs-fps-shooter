using System;
using Scellecs.Morpeh;
using UnityEngine;
using Zenject;

namespace _project.ecs_learning.Scripts.MainInstaller
{
    public abstract class Executor : IInitializable, ITickable, IFixedTickable, ILateTickable, IDisposable
    {
        protected readonly SystemsGroup InitializeSystems;
        protected readonly SystemsGroup UpdateSystems;
        protected readonly SystemsGroup FixedUpdateSystems;
        protected readonly SystemsGroup LateUpdateSystems;

        protected Executor(World world)
        {
            InitializeSystems = world.CreateSystemsGroup();
            UpdateSystems = world.CreateSystemsGroup();
            FixedUpdateSystems = world.CreateSystemsGroup();
            LateUpdateSystems = world.CreateSystemsGroup();
        }
        
        public void Initialize()
        {
            InitializeSystems.Initialize();
            UpdateSystems.Initialize();
            FixedUpdateSystems.Initialize();
            LateUpdateSystems.Initialize();
        }

        public void Tick()
        {
            UpdateSystems.Update(Time.deltaTime);
        }

        public void FixedTick()
        {
            FixedUpdateSystems.FixedUpdate(Time.fixedDeltaTime);
        }

        public void LateTick()
        {
            LateUpdateSystems.LateUpdate(Time.deltaTime);
        }

        public void Dispose()
        {
            InitializeSystems.Dispose();
            UpdateSystems.Dispose();
            FixedUpdateSystems.Dispose();
            LateUpdateSystems.Dispose();
        }
    }
}