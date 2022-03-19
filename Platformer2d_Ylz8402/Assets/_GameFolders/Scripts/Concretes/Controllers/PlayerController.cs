using Platformer2d.Abstracts.Controllers;
using Platformer2d.Abstracts.Inputs;
using Platformer2d.Abstracts.Movements;
using Platformer2d.Inputs;
using Platformer2d.Movements;
using UnityEngine;

namespace Platformer2d.Controllers
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        IMover _mover;
        IJump _jump;
        
        public IInputReader InputReader { get; private set; }

        void Awake()
        {
            InputReader = new NewInputReader();
            _mover = new PlayerVelocityMove(this);
            _jump = new PlayerJumpForce(this);
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
    }
}