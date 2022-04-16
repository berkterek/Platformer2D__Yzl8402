using Platformer2d.Abstracts.Combats;
using Platformer2d.Abstracts.Controllers;

namespace Platformer2d.Combats
{
    public class PlayerHealth : Health
    {
        readonly IPlayerController _playerController;
        
        public PlayerHealth(IPlayerController playerController) : base(playerController.Stats)
        {
            _playerController = playerController;
            _playerController.PlayerData.HealthEvent.Notify(CurrentHealth);
        }

        public override void TakeDamage(IAttacker attacker)
        {
            base.TakeDamage(attacker);
            _playerController.PlayerData.HealthEvent.Notify(CurrentHealth);
        }

        public override void IncreaseHealth(int healthValue)
        {
            base.IncreaseHealth(healthValue);
            _playerController.PlayerData.HealthEvent.Notify(CurrentHealth);
        }
    }
}