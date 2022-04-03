using Platformer2d.Abstracts.Animations;
using Platformer2d.Abstracts.Combats;
using Platformer2d.Abstracts.Controllers;
using Platformer2d.Abstracts.DataContainers;
using Platformer2d.Abstracts.Inputs;
using Platformer2d.Abstracts.Movements;
using Platformer2d.Animations;
using Platformer2d.Combats;
using Platformer2d.Inputs;
using Platformer2d.Movements;
using Platformer2d.ScriptableObjects;
using UnityEngine;

namespace Platformer2d.Controllers
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        [SerializeField] PlayerDataContainer _playerData;
        [SerializeField] Transform _startPoint;
        
        IMover _mover;
        IJump _jump;
        IAnimator _animator;
        IPlayerFlip _flip;
        
        public IInputReader InputReader { get; private set; }
        public IGroundChecker GroundChecker { get; private set; }
        public IPlayerStats Stats => _playerData.Stats;
        public IHealth Health { get; private set; }
        public IAttacker Attacker { get; private set; }

        void Awake()
        {
            InputReader = new NewInputReader();
            _mover = new PlayerTranslateMove(this);
            _jump = new PlayerJumpForce(this);
            _animator = new PlayerAnimationWithAnimator(this);
            _flip = new PlayerSpriteRenderFlip(this);
            Health = new Health(_playerData.Stats);
            Attacker = new Attacker();
            GroundChecker = GetComponent<IGroundChecker>();
        }

        void OnEnable()
        {
            Health.OnTookHit += HandleOnTookHit;
            Health.OnDead += HandleOnDead;
        }

        void OnDisable()
        {
            Health.OnTookHit -= HandleOnTookHit;
            Health.OnDead -= HandleOnDead;
        }

        void Update()
        {
            _mover.Tick();
            _jump.Tick();
            _flip.Tick();
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
            _jump.FixedTick();
        }

        void LateUpdate()
        {
            _animator.LateTick();
            _flip.LateTick();
            _jump.LateUpdate();
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.collider.TryGetComponent(out IEnemyController enemyController)) return;

            if (other.contacts[0].normal != Vector2.up) return;
            
            enemyController.Health.TakeDamage(Attacker);
        }

        void HandleOnTookHit()
        {
            transform.position = _startPoint.position;
        }
        
        void HandleOnDead()
        {
            Destroy(this.gameObject);
        }
    }
}