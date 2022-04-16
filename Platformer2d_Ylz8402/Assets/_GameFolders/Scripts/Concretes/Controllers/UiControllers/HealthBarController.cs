using Platformer2d.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer2d.Controllers.Uis
{
    public class HealthBarController : MonoBehaviour
    {
        [SerializeField] IntEventWithOneParameterSO _healthEvent;
        [SerializeField] Image[] _healthSlots;

        void Awake()
        {
            GetReference();
        }
        
        void OnValidate()
        {
            GetReference();
        }

        void OnEnable()
        {
            _healthEvent.OnIntEventOneParameterTriggered += HandleOnHealthChanged;
        }

        void OnDisable()
        {
            _healthEvent.OnIntEventOneParameterTriggered -= HandleOnHealthChanged;
        }

        private void GetReference()
        {
            if (_healthSlots.Length <= 0 || _healthSlots.Length != this.transform.childCount)
            {
                _healthSlots = this.transform.GetComponentsInChildren<Image>();
            }
        }
        
        void HandleOnHealthChanged(int currentHealth)
        {
            for (int i = 0; i < _healthSlots.Length; i++)
            {
                _healthSlots[i].enabled = false;
            }
            
            for (int i = 0; i < currentHealth; i++)
            {
                _healthSlots[i].enabled = true;
            }
        }
    }    
}