using UnityEngine;

namespace _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours
{
    public class UiRoot : MonoBehaviour
    {
        [SerializeField] private Window[] _windows;

        public T GetWindow<T>() where T : Window
        {
            for (int i = 0; i < _windows.Length; i++)
            {
                if (_windows[i].GetType() == typeof(T))
                {
                    return _windows[i] as T;
                }
            }
            
            return null;
        }
    }
}