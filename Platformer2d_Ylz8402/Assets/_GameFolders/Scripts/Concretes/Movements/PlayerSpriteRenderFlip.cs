using Platformer2d.Abstracts.Controllers;
using UnityEngine;

namespace Platformer2d.Movements
{
    public class PlayerSpriteRenderFlip : IPlayerFlip
    {
        readonly IPlayerController _playerController;
        readonly SpriteRenderer _spriteRenderer;
        
        float _horizontal;
        bool _result;
        
        public PlayerSpriteRenderFlip(IPlayerController playerController)
        {
            Debug.Log($"Flip => {nameof(PlayerSpriteRenderFlip)}");
            _playerController = playerController;
            _spriteRenderer = _playerController.transform.GetComponentInChildren<SpriteRenderer>();
        }

        public void Tick()
        {
            _horizontal = _playerController.InputReader.Horizontal;
        }

        public void LateTick()
        {
            if (_horizontal == 0f) return;
            
            _result =_horizontal < 0f;

            if (_result == _spriteRenderer.flipX) return;

            FlipProcess();
        }

        public void FlipProcess()
        {
            _spriteRenderer.flipX = _result;
        }
    }
}
