using _project.ecs_learning.Scripts.ModuleCamera.Providers;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleCamera.Configs
{
    [CreateAssetMenu(fileName = "PlayerCameraConfig", menuName = "Data/Camera/PlayerCameraConfig")]
    public class PlayerCameraConfig : ScriptableObject
    {
        [SerializeField] private CameraProvider _prefab;
        [Space]
        [SerializeField] private float _horizontalSightSpeed; 
        [SerializeField] private float _verticalSightSpeed;
        [SerializeField] private float _minVerticalValue;
        [SerializeField] private float _maxVerticalValue;

        public CameraProvider Prefab => _prefab;
        
        public float HorizontalSightSpeed => _horizontalSightSpeed;
        public float VerticalSightSpeed => _verticalSightSpeed;
        public float MinVerticalValue => _minVerticalValue;
        public float MaxVerticalValue => _maxVerticalValue;
    }
}