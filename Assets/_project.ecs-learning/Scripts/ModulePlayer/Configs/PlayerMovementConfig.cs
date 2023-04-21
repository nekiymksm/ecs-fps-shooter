using UnityEngine;

namespace _project.ecs_learning.Scripts.ModulePlayer.Configs
{
    [CreateAssetMenu(fileName = "PlayerMovementConfig", menuName = "Data/Player/MovementConfig")]
    public class PlayerMovementConfig : ScriptableObject
    {
        [SerializeField] private float _walkSpeed;

        public float WalkSpeed => _walkSpeed;
    }
}