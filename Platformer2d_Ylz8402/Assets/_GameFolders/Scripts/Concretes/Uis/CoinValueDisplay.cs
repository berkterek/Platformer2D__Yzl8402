using Platformer2d.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace Platformer2d.Uis
{
    public class CoinValueDisplay : MonoBehaviour
    {
        [SerializeField] PlayerDataContainer _playerDataContainer;
        [SerializeField] TMP_Text _text;

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
            _playerDataContainer.OnCoinValueChanged += HandleOnCoinValueChanged;
        }

        void OnDisable()
        {
            _playerDataContainer.OnCoinValueChanged -= HandleOnCoinValueChanged;
        }
        
        void HandleOnCoinValueChanged(int coinValue)
        {
            _text.SetText(coinValue.ToString());
        }

        private void GetReference()
        {
            if (_text == null)
            {
                _text = GetComponent<TMP_Text>();
            }
        }
    }    
}

