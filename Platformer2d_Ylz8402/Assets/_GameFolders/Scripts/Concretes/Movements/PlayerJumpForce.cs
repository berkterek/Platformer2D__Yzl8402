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
                _rigidbody2D.velocity = Vector2.zero;
                _rigidbody2D.AddForce(Vector2.up * _playerController.Stats.JumpForce * Time.deltaTime);
            }

            _isJump = false;
        }
    }    
}