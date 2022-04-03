using System;
using Platformer2d.Abstracts.DataContainers;
using UnityEngine;

namespace Platformer2d.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player Data Container",menuName = "Bilge Adam/Data/Player Data Container")]
    public class PlayerDataContainer : ScriptableObject,IPlayerDataContainer
    {
        [SerializeField] int _currentCoin = 0;
        [SerializeField] PlayerStatsSO _playerStats;

        public int CurrentCoin => _currentCoin;
        public IPlayerStats Stats => _playerStats;

        void OnDisable()
        {
            _currentCoin = 0;
        }

        public void IncreaseCoin(int coinValue)
        {
            _currentCoin += coinValue;
        }

        public bool DecreaseCoin(int coinValue)
        {
            int resultValue = _currentCoin - coinValue;

            if (resultValue < 0)
            {
                return false;
            }

            _currentCoin = resultValue;
            return true;
        }
    }
}