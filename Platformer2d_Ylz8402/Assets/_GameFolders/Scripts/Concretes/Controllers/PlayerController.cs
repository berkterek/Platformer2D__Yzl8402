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
        [SerializeField] PlayerStatsSO _stats;
        [SerializeField] Transform _startPoint;
        
        IMover _mover;
        IJump _jump;
        IAnimator _animator;
        IPlayerFlip _flip;
        
        public IInputReader InputReader { get; private set; }
        public IGroundChecker GroundChecker { get; private set; }
        public IPlayerStats Stats => _stats;
        public IHealth Health { get; private set; }

        void Awake()
        {
            InputReader = new NewInputReader();
            _mover = new PlayerVelocityMove(this);
            _jump = new PlayerJumpForce(this);
            _animator = new PlayerAnimationWithAnimator(this);
            _flip = new PlayerSpriteRenderFlip(this);
            Health = new Health(this);
            GroundChecker = GetComponent<IGroundChecker>();
        }

        void OnEnable()
        {
            Health.OnTookHit += HandleOnTookHit;
        }

        void OnDisable()
        {
            Health.OnTookHit -= HandleOnTookHit;
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

        void HandleOnTookHit()
        {
            transform.position = _startPoint.position;
        }
    }
}