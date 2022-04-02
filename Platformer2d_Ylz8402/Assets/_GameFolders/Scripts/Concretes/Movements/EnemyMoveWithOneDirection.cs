using Platformer2d.Abstracts.Controllers;
using Platformer2d.Abstracts.Movements;
using UnityEngine;

namespace Platformer2d.Movements
{
    public class EnemyMoveWithOneDirection : IMover
    {
        readonly Transform _transform;
        readonly ISlimeEnemyController _enemyController;
        
        public EnemyMoveWithOneDirection(ISlimeEnemyController enemyController)
        {
            _transform = enemyController.transform;
            _enemyController = enemyController;
        }
        
        public void Tick()
        {
            if (!_enemyController.GroundChecker.IsOnGround)
            {
                _enemyController.Direction *= -1f;
                _enemyController.Flip.FlipProcess();
            }
        }

        public void FixedTick()
        {
            _transform.Translate(Vector2.right * _enemyController.Direction * _enemyController.MoveSpeed * Time.deltaTime);
        }
    }
}