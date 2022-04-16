using Platformer2d.Abstracts.DataContainers;
using UnityEngine;

namespace Platformer2d.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player Data Container",menuName = "Bilge Adam/Data/Player Data Container")]
    public class PlayerDataContainer : ScriptableObject,IPlayerDataContainer
    {
        [SerializeField] int _currentCoin = 0;
        [SerializeField] PlayerStatsSO _playerStats;
        [SerializeField] IntEventWithOneParameterSO _healthEvent;

        public int CurrentCoin => _currentCoin;
        public IPlayerStats Stats => _playerStats;
        public IntEventWithOneParameterSO HealthEvent => _healthEvent;
        public event System.Action<int> OnCoinValueChanged;

        void OnDisable()
        {
            _currentCoin = 0;
        }

        public void IncreaseCoin(int coinValue)
        {
            _currentCoin += coinValue;
            OnCoinValueChanged?.Invoke(_currentCoin);
        }

        public bool DecreaseCoin(int coinValue)
        {
            int resultValue = _currentCoin - coinValue;

            if (resultValue < 0)
            {
                return false;
            }

            _currentCoin = resultValue;
            OnCoinValueChanged?.Invoke(_currentCoin);
            return true;
        }
    }
}