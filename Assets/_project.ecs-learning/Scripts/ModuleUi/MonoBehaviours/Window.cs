using Scellecs.Morpeh;
using UnityEngine;
using UnityEngine.UI;

namespace _project.ecs_learning.Scripts.ModuleUi.MonoBehaviours
{
    public abstract class Window : MonoBehaviour
    {
        protected Entity WindowEntity;

        public void Init(Entity entity)
        {
            WindowEntity = entity;
            
            SetElements();
        }
        
        protected virtual void SetElements() {}
        
        protected void AddButtonListener<T>(Button button) where T : struct, IComponent
        {
            button.onClick.AddListener(() => WindowEntity.AddComponent<T>());
        }
    }
}