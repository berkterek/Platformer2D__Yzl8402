using Platformer2d.Abstracts.Animations;
using Platformer2d.Abstracts.Controllers;
using Platformer2d.Abstracts.Inputs;
using Platformer2d.Abstracts.Movements;
using Platformer2d.Animations;
using Platformer2d.Inputs;
using Platformer2d.Movements;
using UnityEngine;

namespace Platformer2d.Controllers
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        IMover _mover;
        IJump _jump;
        IAnimator _animator;
        
        public IInputReader InputReader { get; private set; }

        void Awake()
        {
            InputReader = new NewInputReader();
            _mover = new PlayerVelocityMove(this);
            _jump = new PlayerJumpForce(this);
            _animator = new PlayerAnimationWithAnimator(this);
        }

        void Update()
        {
            _mover.Tick();
            _jump.Tick();
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
            _jump.FixedTick();
        }

        void LateUpdate()
        {
            _animator.LateTick();
        }
    }
}