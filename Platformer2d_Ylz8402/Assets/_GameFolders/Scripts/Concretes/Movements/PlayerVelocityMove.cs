using Platformer2d.Abstracts.Controllers;
using Platformer2d.Abstracts.Movements;
using UnityEngine;

namespace Platformer2d.Movements
{
    public class PlayerVelocityMove : IMover
    {
        readonly IPlayerController _playerController;
        readonly Rigidbody2D _rigidbody2D;

        float _horizontal;
        
        public PlayerVelocityMove(IPlayerController playerController)
        {
            Debug.Log($"Mover Name : {nameof(PlayerVelocityMove)}");
            _playerController = playerController;
            _rigidbody2D = playerController.transform.GetComponent<Rigidbody2D>();
        }
        
        public void Tick()
        {
            _horizontal = _playerController.InputReader.Horizontal;
            _horizontal *= Time.deltaTime * _playerController.Stats.MoveSpeed;
        }

        public void FixedTick()
        {
            float x = _horizontal;
            float y = _rigidbody2D.velocity.y;
            Vector3 direction = new Vector3(x, y);
            _rigidbody2D.velocity = direction;
        }
    }
}