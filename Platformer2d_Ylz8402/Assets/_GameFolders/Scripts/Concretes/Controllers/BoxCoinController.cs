using Platformer2d.Abstracts.Controllers;
using UnityEngine;

namespace Platformer2d.Controllers
{
    public class BoxCoinController : MonoBehaviour
    {
        [SerializeField] Sprite _endSprite;
        [SerializeField] int _coinPoint = 1;
        [SerializeField] int _counter = 5;

        SpriteRenderer _spriteRenderer;
        
        void Awake()
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.collider.TryGetComponent(out IPlayerController playerController)) return;
            if (other.contacts[0].normal.y != 1f) return;
            
            CollectedProcess(playerController);
        }
        
        private void CollectedProcess(IPlayerController playerController)
        {
            _counter--;
            
            if (_counter > 0)
            {
                playerController.IncreaseCoin(_coinPoint);    
            }
            else if (_counter == 0)
            {
                playerController.IncreaseCoin(_coinPoint);
                _spriteRenderer.sprite = _endSprite;
            }
        }
    }
}