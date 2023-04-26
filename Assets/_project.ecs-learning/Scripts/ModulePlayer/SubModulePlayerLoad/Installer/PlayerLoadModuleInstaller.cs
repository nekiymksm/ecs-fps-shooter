using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerLoad.Systems;
using Zenject;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerLoad.Installer
{
    public class PlayerLoadModuleInstaller : Installer<PlayerLoadModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerLoadStartSystem>().AsSingle();
            Container.Bind<PlayerLoadViewSystem>().AsSingle();
            Container.Bind<PlayerLoadCameraTrackSystem>().AsSingle();
            Container.Bind<PlayerLoadMovementDataSystem>().AsSingle();
            Container.Bind<PlayerLoadShootingDataSystem>().AsSingle();
            Container.Bind<PlayerLoadEndSystem>().AsSingle();

            Container.Bind<PlayerSetOnSpawnPointSystem>().AsSingle();
            Container.Bind<PlayerCollapseSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<PlayerLoadModuleExecutor>().AsSingle();
        }
    }
}