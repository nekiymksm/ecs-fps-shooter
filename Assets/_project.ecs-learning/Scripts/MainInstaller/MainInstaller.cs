using _project.ecs_learning.Scripts.ModuleCamera.Installer;
using _project.ecs_learning.Scripts.ModuleCollisionsHandle.Installer;
using _project.ecs_learning.Scripts.ModuleEnemies.Installer;
using _project.ecs_learning.Scripts.ModuleEntityControl.Installer;
using _project.ecs_learning.Scripts.ModuleGameState.Installer;
using _project.ecs_learning.Scripts.ModulePlayer.Installer;
using _project.ecs_learning.Scripts.ModuleMaps.Installer;
using _project.ecs_learning.Scripts.ModuleStages.Installer;
using _project.ecs_learning.Scripts.ModuleUi.Installer;
using _project.ecs_learning.Scripts.ModuleUtilities.Installer;
using _project.ecs_learning.Scripts.ModuleWeapon.Installer;
using Scellecs.Morpeh;
using UnityEngine;
using Zenject;

namespace _project.ecs_learning.Scripts.MainInstaller
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private MainConfig _mainConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(World.Default);
            
            EntityControlModuleInstaller.Install(Container);
            GameStateModuleInstaller.Install(Container);
            
            StagesModuleInstaller.Install(Container, _mainConfig);
            MapsModuleInstaller.Install(Container, _mainConfig);
            PlayerModuleInstaller.Install(Container, _mainConfig);
            CameraModuleInstaller.Install(Container, _mainConfig);
            WeaponModuleInstaller.Install(Container, _mainConfig);
            EnemiesModuleInstaller.Install(Container, _mainConfig);
            CollisionsHandleModuleInstaller.Install(Container);
            
            UiModuleInstaller.Install(Container, _mainConfig);
            UtilitiesModuleInstaller.Install(Container);
        }
    }
}