using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows;
using _project.ecs_learning.Scripts.ModuleUi.SubModuleWeaponMenu.Components;
using Scellecs.Morpeh;

namespace _project.ecs_learning.Scripts.ModuleUi.SubModuleWeaponMenu.Systems
{
    public class WeaponMenuInitSystem : IInitializer
    {
        private UiRoot _uiRoot;
        
        public World World { get; set; }

        public WeaponMenuInitSystem(UiRoot uiRoot)
        {
            _uiRoot = uiRoot;
        }
        
        public void OnAwake()
        {
            Entity entity = World.CreateEntity();
            entity.SetComponent(new WeaponMenuComponent());
            
            _uiRoot.GetWindow<WeaponMenu>().Init(entity);
        }

        public void Dispose()
        {
        }
    }
}