using _project.ecs_learning.Scripts.ModuleMaps.Providers;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleMaps.Configs
{
    [CreateAssetMenu(fileName = "MapsCollection", menuName = "Data/MapsCollection")]
    public class MapsCollection : ScriptableObject
    { 
        [SerializeField] private MapProvider[] _prefabs;

        public MapProvider[] Prefabs => _prefabs;
    }
}