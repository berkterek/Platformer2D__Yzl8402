using Platformer2d.Abstracts.Controllers;
using UnityEngine;

namespace Platformer2d.Movements
{
    public class PlayerSpriteRenderFlip : IFlip
    {
        readonly IPlayerController _playerController;
        readonly SpriteRenderer _spriteRenderer;
        
        float _horizontal;
        
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
            
            bool result =_horizontal < 0f;

            if (result == _spriteRenderer.flipX) return;

            _spriteRenderer.flipX = result;
        }
    }
}
