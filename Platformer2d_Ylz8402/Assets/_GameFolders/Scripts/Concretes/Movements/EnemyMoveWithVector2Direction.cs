using Platformer2d.Abstracts.Controllers;
using Platformer2d.Abstracts.Movements;
using UnityEngine;

namespace Platformer2d.Movements
{
    public class EnemyMoveWithVector2Direction : IMover
    {
        readonly IFlyEnemyController _flyEnemyController;
        readonly Transform _transform;
        readonly Vector3 _startPosition;

        public EnemyMoveWithVector2Direction(IFlyEnemyController flyEnemyController)
        {
            _flyEnemyController = flyEnemyController;
            _transform = flyEnemyController.transform;
            _startPosition = _transform.position;
        }

        public void Tick()
        {
            float distance = Vector3.Distance(_transform.position, _startPosition);

            if (distance > _flyEnemyController.MaxDistance)
            {
                _transform.position = _startPosition +
                                      (_flyEnemyController.Direction.normalized * _flyEnemyController.MaxDistance);
                _flyEnemyController.Direction *= -1f;
            }
        }

        public void FixedTick()
        {
            _transform.Translate(_flyEnemyController.Direction * Time.deltaTime * _flyEnemyController.MoveSpeed);
        }
    }
}