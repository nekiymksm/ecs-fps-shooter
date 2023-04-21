using _project.ecs_learning.Scripts.ModuleEnemies.SubModuleEnemiesLoad.Providers;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleEnemies.Configs
{
    [CreateAssetMenu(fileName = "EnemiesCollection", menuName = "Data/Enemies/EnemiesCollection")]
    public class EnemiesCollection : ScriptableObject
    {
        [SerializeField] private EnemyProvider[] _prefabs;

        public EnemyProvider[] Prefabs => _prefabs;
    }
}