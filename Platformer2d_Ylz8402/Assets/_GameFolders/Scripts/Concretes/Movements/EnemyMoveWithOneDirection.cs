using Platformer2d.Abstracts.Controllers;
using Platformer2d.Abstracts.Movements;
using UnityEngine;

namespace Platformer2d.Movements
{
    public class EnemyMoveWithOneDirection : IMover
    {
        readonly Transform _transform;
        readonly ISlimeEnemyController _enemyController;
        readonly float _moveSpeed;
        
        public EnemyMoveWithOneDirection(ISlimeEnemyController enemyController)
        {
            _transform = enemyController.transform;
            _enemyController = enemyController;
            _moveSpeed = _enemyController.Stats.MoveSpeed;
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
            _transform.Translate(Vector2.right * _enemyController.Direction * _moveSpeed * Time.deltaTime);
        }
    }
}