using Platformer2d.Abstracts.Combats;
using Platformer2d.Abstracts.Controllers;

namespace Platformer2d.Combats
{
    public class EnemyHealth : Health
    {
        public EnemyHealth(IEnemyController enemyController) : base(enemyController.Stats)
        {
            
        }
    }
}