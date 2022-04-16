using Platformer2d.Abstracts.Controllers;
using Platformer2d.Abstracts.Movements;
using Platformer2d.Movements;
using UnityEngine;

namespace Platformer2d.Controllers
{
    public class SlimeEnemyController : EnemyController,ISlimeEnemyController
    {
        [SerializeField] float _direction = 1f;
        [SerializeField] Transform _body;

        bool _canEnemyGoForward;
        public IFlip Flip { get; private set; }
        
        public float Direction { get => _direction; set => _direction = value; }
        public IGroundChecker GroundChecker { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            
            GroundChecker = GetComponent<RaycastGroundChecker>();
            Flip = new EnemyScaleFlip(_body);
            _mover = new EnemyMoveWithOneDirection(this);
        }
    }
}