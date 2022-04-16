using UnityEngine;

namespace Platformer2d.Abstracts.ScriptableObjects
{
    public abstract class BaseEventOneParameterSO<T> : ScriptableObject
    {
        public event System.Action<T> OnIntEventOneParameterTriggered;

        public virtual void Notify(T value)
        {
            OnIntEventOneParameterTriggered?.Invoke(value);
        }
    }
}