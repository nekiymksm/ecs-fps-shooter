﻿using _project.ecs_learning.Scripts.ModuleEnemies.SubModuleEnemiesLoad.Systems;
using Zenject;

namespace _project.ecs_learning.Scripts.ModuleEnemies.SubModuleEnemiesLoad.Installer
{
    public class EnemiesLoadModuleInstaller : Installer<EnemiesLoadModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<EnemiesCollapseSystem>().AsSingle();
            Container.Bind<EnemiesLoadSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<EnemiesLoadModuleExecutor>().AsSingle();
        }
    }
}