using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerDefeat.Systems;
using Zenject;

namespace _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerDefeat.Installer
{
    public class PlayerDefeatModuleInstaller : Installer<PlayerDefeatModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerDefeatSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<PlayerDefeatModuleExecutor>().AsSingle();
        }
    }
}