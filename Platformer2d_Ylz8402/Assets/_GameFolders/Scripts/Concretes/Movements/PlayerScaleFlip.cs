using Platformer2d.Abstracts.Controllers;
using UnityEngine;

namespace Platformer2d.Movements
{
    public class PlayerScaleFlip : IPlayerFlip
    {
        readonly IPlayerController _playerController;
        readonly Transform _transform;

        float _horizontal;

        public PlayerScaleFlip(IPlayerController playerController)
        {
            Debug.Log($"Flip => {nameof(PlayerScaleFlip)}");
            _playerController = playerController;
            _transform = _playerController.transform.GetChild(0).transform;
        }

        public void Tick()
        {
            _horizontal = _playerController.InputReader.Horizontal;
        }

        public void LateTick()
        {
            if (_horizontal == 0f) return;

            _horizontal = _horizontal > 0f ? 1f : -1f;

            if (_horizontal == _transform.localScale.x) return;

            FlipProcess();
        }

        public void FlipProcess()
        {
            _transform.localScale = new Vector3(_horizontal, 1f, 1f);
        }
    }
}