using Platformer2d.Abstracts.Controllers;
using Platformer2d.Abstracts.Movements;
using UnityEngine;

namespace Platformer2d.Abstracts.Controllers
{
    public abstract class EnemyController : MonoBehaviour, IEnemyController
    {
        [SerializeField] protected float _moveSpeed = 1f;

        protected IMover _mover;

        public float MoveSpeed => _moveSpeed;

        void Update()
        {
            _mover.Tick();
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }
    }
}