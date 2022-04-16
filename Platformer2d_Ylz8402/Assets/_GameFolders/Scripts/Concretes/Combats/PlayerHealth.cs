using Platformer2d.Abstracts.Combats;
using Platformer2d.Abstracts.Controllers;
using Platformer2d.Abstracts.DataContainers;
using UnityEngine;

namespace Platformer2d.Combats
{
    public class PlayerHealth : Health, IPlayerHealth
    {
        const string HEALTH_KEY_VALUE = "string_health_value";
        readonly IPlayerController _playerController;

        public PlayerHealth(IPlayerController playerController) : base(playerController.Stats)
        {
            _playerController = playerController;
            _playerController.PlayerData.HealthEvent.Notify(CurrentHealth);
        }

        protected override void SetHealthInfo(IStats stats)
        {
            MaxHealth = stats.MaxHealth;

            if (!Load())
            {
                CurrentHealth = stats.MaxHealth;
            }
        }

        public override void TakeDamage(IAttacker attacker)
        {
            base.TakeDamage(attacker);
            _playerController.PlayerData.HealthEvent.Notify(CurrentHealth);
            Save();
        }

        public override void IncreaseHealth(int healthValue)
        {
            base.IncreaseHealth(healthValue);
            _playerController.PlayerData.HealthEvent.Notify(CurrentHealth);
            Save();
        }

        protected override void DeadProcess()
        {
            Delete();
            base.DeadProcess();
        }

        void Save()
        {
            PlayerPrefs.SetInt(HEALTH_KEY_VALUE, CurrentHealth);
        }

        bool Load()
        {
            if (PlayerPrefs.HasKey(HEALTH_KEY_VALUE))
            {
                CurrentHealth = PlayerPrefs.GetInt(HEALTH_KEY_VALUE);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Delete()
        {
            if (PlayerPrefs.HasKey(HEALTH_KEY_VALUE))
            {
                PlayerPrefs.DeleteKey(HEALTH_KEY_VALUE);    
            }
        }
    }
}