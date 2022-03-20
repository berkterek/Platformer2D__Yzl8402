using Platformer2d.Abstracts.Controllers;
using Platformer2d.Abstracts.Movements;
using UnityEngine;

namespace Platformer2d.Movements
{
    public class PlayerTranslateMove : IMover
    {
        readonly IPlayerController _playerController;
        readonly Transform _transform;

        float _horizontal;

        public PlayerTranslateMove(IPlayerController playerController)
        {
            Debug.Log($"Mover Name : {nameof(PlayerTranslateMove)}");
            _playerController = playerController;
            _transform = playerController.transform;
        }
        
        public void Tick()
        {
            _horizontal = _playerController.InputReader.Horizontal;
        }

        public void FixedTick()
        {
            _transform.Translate(Vector3.right * _horizontal * Time.deltaTime * _playerController.Stats.MoveSpeed);
        }
    }
}

