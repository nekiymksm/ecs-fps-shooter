using _project.ecs_learning.Scripts.ModuleCamera.Configs;
using _project.ecs_learning.Scripts.ModuleEnemies.Configs;
using _project.ecs_learning.Scripts.ModulePlayer.Configs;
using _project.ecs_learning.Scripts.ModuleMaps.Configs;
using _project.ecs_learning.Scripts.ModuleStages.Configs;
using _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours;
using _project.ecs_learning.Scripts.ModuleWeapon.Configs;
using UnityEngine;

namespace _project.ecs_learning.Scripts.MainInstaller
{
    [CreateAssetMenu(fileName = "MainConfig", menuName = "Data/MainConfig")]
    public class MainConfig : ScriptableObject
    {
        [SerializeField] private UiRoot _uiRootPrefab;
        [Space]
        [SerializeField] private MapsCollection _mapsCollection;
        [SerializeField] private PlayerViewsCollection _playerViewsCollection;
        [SerializeField] private WeaponsCollection _weaponsCollection;
        [SerializeField] private EnemiesCollection _enemiesCollection;
        [SerializeField] private StageInfosCollection _stageInfosCollection;
        [Space]
        [SerializeField] private PlayerMovementConfig _playerMovementConfig;
        [SerializeField] private PlayerCameraConfig _playerCameraConfig;

        public UiRoot UiRootPrefab => _uiRootPrefab;
        
        public MapsCollection MapsCollection => _mapsCollection;
        public PlayerViewsCollection PlayerViewsCollection => _playerViewsCollection;
        public WeaponsCollection WeaponsCollection => _weaponsCollection;
        public EnemiesCollection EnemiesCollection => _enemiesCollection;
        public StageInfosCollection StageInfosCollection => _stageInfosCollection;
        
        public PlayerMovementConfig PlayerMovementConfig => _playerMovementConfig;
        public PlayerCameraConfig PlayerCameraConfig => _playerCameraConfig;
    }
}