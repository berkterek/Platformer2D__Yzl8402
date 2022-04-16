using Platformer2d.Abstracts.Controllers;
using Platformer2d.Movements;
using UnityEngine;

namespace Platformer2d.Controllers
{
    public class FlyEnemyController : EnemyController, IFlyEnemyController
    {
        [SerializeField] float _maxDistance = 3f;
        [SerializeField] Vector3 _direction;

        public float MaxDistance => _maxDistance;
        public Vector3 Direction { get => _direction; set => _direction = value; }
        
        protected override void Awake()
        {
            base.Awake();
            
            _mover = new EnemyMoveWithVector2Direction(this);
        }
    }
}