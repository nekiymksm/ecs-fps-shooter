using _project.ecs_learning.Scripts.ModulePlayer.MonoBehaviours;
using _project.ecs_learning.Scripts.ModulePlayer.SubModulePlayerLoad.Providers;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModulePlayer.Configs
{
    [CreateAssetMenu(fileName = "PlayerViewsCollection", menuName = "Data/Player/ViewsCollection")]
    public class PlayerViewsCollection : ScriptableObject
    {
        [SerializeField] private PlayerProvider _prefab;
        [SerializeField] private PlayerView[] _views;
        
        public PlayerProvider Prefab => _prefab;
        public PlayerView[] Views => _views;
    }
}