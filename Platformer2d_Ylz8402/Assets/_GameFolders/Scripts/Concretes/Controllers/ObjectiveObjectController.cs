using Platformer2d.Abstracts.Controllers;
using UnityEngine;

namespace Platformer2d.Controllers
{
    public class ObjectiveObjectController : MonoBehaviour
    {
        [SerializeField] SpriteRenderer _spriteRenderer;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out IPlayerController playerController)) return;

            playerController.ObjectiveSpriteRenderer.sprite = _spriteRenderer.sprite;
            Destroy(this.gameObject);
        }
    }    
}

