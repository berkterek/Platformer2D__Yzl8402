using Platformer2d.Abstracts.Combats;
using Platformer2d.Abstracts.Movements;
using Platformer2d.Combats;
using UnityEngine;

namespace Platformer2d.Abstracts.Controllers
{
    public abstract class EnemyController : MonoBehaviour, IEnemyController
    {
        [SerializeField] protected float _moveSpeed = 1f;

        protected IMover _mover;

        public float MoveSpeed => _moveSpeed;
        public IAttacker Attacker { get; private set; }

        protected virtual void Awake()
        {
            Attacker = new Attacker();
        }

        void Update()
        {
            _mover.Tick();
        }
        
        void FixedUpdate()
        {
            _mover.FixedTick();
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.collider.TryGetComponent(out IPlayerController playerController)) return;

            if (other.contacts[0].normal == Vector2.down) return;
            
            playerController.Health.TakeDamage(Attacker);
        }
    }
}