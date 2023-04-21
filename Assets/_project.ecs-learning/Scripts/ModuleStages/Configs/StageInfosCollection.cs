using System;
using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleStages.Configs
{
    [CreateAssetMenu(fileName = "StagesCollection", menuName = "Data/StagesCollection")]
    public class StageInfosCollection : ScriptableObject
    {
        [SerializeField] private StageInfo[] _stageInfos;

        public StageInfo[] StageInfos => _stageInfos;
    }

    [Serializable]
    public class StageInfo
    {
        [SerializeField] private int _stageId;
        [SerializeField] private int _enemiesCountToWin;

        public int StageId => _stageId;
        public int EnemiesCountToWin => _enemiesCountToWin;
    }
}