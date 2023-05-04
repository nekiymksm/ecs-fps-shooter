using _project.ecs_learning.Scripts.ModuleUi.SubModuleWeaponMenu.Components;
using UnityEngine;
using UnityEngine.UI;

namespace _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours.Windows
{
    public class WeaponMenu : Window
    {
        [SerializeField] private Button _pistol;
        [SerializeField] private Button _smg;
        [SerializeField] private Button _shotgun;

        protected override void SetElements()
        {
            AddButtonListener<WeaponMenuPistolButtonMarker>(_pistol);
            AddButtonListener<WeaponMenuSmgButtonMarker>(_smg);
            AddButtonListener<WeaponMenuShotgunButtonMarker>(_shotgun);
        }
    }
}