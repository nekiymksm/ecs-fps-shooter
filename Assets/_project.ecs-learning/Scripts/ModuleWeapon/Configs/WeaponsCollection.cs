using System;
using _project.ecs_learning.Scripts.ModuleWeapon.Providers;
using _project.ecs_learning.Scripts.ModuleWeapon.Utilities;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleWeapon.Configs
{
    [CreateAssetMenu(fileName = "WeaponsCollection", menuName = "Data/WeaponsCollection")]
    public class WeaponsCollection : ScriptableObject
    {
        [SerializeField] private WeaponConfig[] _weaponConfigs;

        public WeaponConfig GetConfig(WeaponKind kind)
        {
            for (int i = 0; i < _weaponConfigs.Length; i++)
            {
                if (_weaponConfigs[i].Kind == kind)
                {
                    return _weaponConfigs[i];
                }
            }

            return null;
        }
    }

    [Serializable]
    public class WeaponConfig
    {
        [SerializeField] private WeaponKind _kind;
        [SerializeField] private ProjectileProvider _projectilePrefab;
        [SerializeField] private float _projectileMoveSpeed;
        [SerializeField] private float _projectileMaxMoveDistance;
        [SerializeField] private bool _isAutomatic;

        public WeaponKind Kind => _kind;
        public ProjectileProvider ProjectilePrefab => _projectilePrefab;
        public float ProjectileMoveSpeed => _projectileMoveSpeed;
        public float ProjectileMaxMoveDistance => _projectileMaxMoveDistance;
        public bool IsAutomatic => _isAutomatic;
    }
}