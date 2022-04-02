using Platformer2d.Abstracts.Controllers;
using Platformer2d.Abstracts.Movements;
using UnityEngine;

namespace Platformer2d.Movements
{
    public class PlayerJumpForce : IJump
    {
        readonly Rigidbody2D _rigidbody2D;
        readonly IPlayerController _playerController;

        bool _isJump;
        int _currentJumpCounter = 0;
        float _currentDelayTime;

        bool CanJump => _currentJumpCounter <= _playerController.Stats.MaxJumpCount;

        public PlayerJumpForce(IPlayerController playerController)
        {
            Debug.Log($"Jump => {nameof(PlayerJumpForce)}");
            _rigidbody2D = playerController.transform.GetComponent<Rigidbody2D>();
            _playerController = playerController;
        }

        public void Tick()
        {
            if (_playerController.InputReader.IsJumpButtonPressed)
            {
                _isJump = true;
            }
        }

        public void FixedTick()
        {
            if (_isJump)
            {
                _currentJumpCounter++;

                if (CanJump)
                {
                    JumpProcess();
                }
            }

            _isJump = false;
        }

        public void LateUpdate()
        {
            if (_playerController.GroundChecker.IsOnGround && _currentJumpCounter != 0)
            {
                _currentDelayTime += Time.deltaTime;
                
                if (_currentDelayTime > 0.1f)
                {
                    _currentJumpCounter = 0;
                    _currentDelayTime = 0f;
                }
            }
        }

        private void JumpProcess()
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Vector2.up * _playerController.Stats.JumpForce * Time.deltaTime);
        }
    }
}