using Platformer2d.Abstracts.Controllers;
using UnityEngine;

namespace Platformer2d.Controllers
{
    public class ObjectiveController : MonoBehaviour
    {
        [SerializeField] Sprite _doorTopSprite;
        [SerializeField] Sprite _doorBottomSprite;

        [SerializeField] SpriteRenderer _doorTopSpriteRender;
        [SerializeField] SpriteRenderer _doorBottomSpriteRender;

        [SerializeField] GameObject _nextLevelObject;
        [SerializeField] BoxCollider2D _boxCollider2D;
        
        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out IPlayerController playerController)) return;
            if (playerController.ObjectiveSpriteRenderer.sprite == null) return;

            ObjectiveDone(playerController);
        }

        void ObjectiveDone(IPlayerController playerController)
        {
            _boxCollider2D.enabled = false;
            playerController.ObjectiveSpriteRenderer.sprite = null;
            
            _doorBottomSpriteRender.sprite = _doorBottomSprite;
            _doorTopSpriteRender.sprite = _doorTopSprite;
            
            _nextLevelObject.SetActive(true);
        }
    }
}