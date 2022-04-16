using Platformer2d.Abstracts.Combats;
using Platformer2d.Abstracts.DataContainers;
using Platformer2d.Abstracts.Movements;
using Platformer2d.Combats;
using Platformer2d.ScriptableObjects;
using UnityEngine;

namespace Platformer2d.Abstracts.Controllers
{
    public abstract class EnemyController : MonoBehaviour, IEnemyController
    {
        [SerializeField] EnemyStatsSO _enemyStats; 

        protected IMover _mover;
        public IAttacker Attacker { get; private set; }
        public IHealth Health { get; private set; }
        public IEnemyStats Stats => _enemyStats;

        protected virtual void Awake()
        {
            Attacker = new Attacker();
            Health = new EnemyHealth(this);
        }

        void OnEnable()
        {
            Health.OnDead += HandleOnDead;
        }

        void OnDisable()
        {
            Health.OnDead -= HandleOnDead;
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
        
        void HandleOnDead()
        {
            Destroy(this.gameObject);
        }
    }
}