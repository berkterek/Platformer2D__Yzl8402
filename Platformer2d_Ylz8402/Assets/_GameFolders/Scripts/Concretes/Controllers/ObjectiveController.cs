using Platformer2d.Abstracts.Controllers;
using Platformer2d.ScriptableObjects;
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

        
        [SerializeField] OpenCloseSaveLoadDataContainer _openCloseSaveLoad;

        void OnEnable()
        {
            if (_openCloseSaveLoad.IsOpen)
            {
                ObjectiveDone();
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out IPlayerController playerController)) return;
            if (playerController.ObjectiveSpriteRenderer.sprite == null) return;
            
            playerController.ObjectiveSpriteRenderer.sprite = null;
            _openCloseSaveLoad.IsOpen = true;
            
            ObjectiveDone();
        }

        void ObjectiveDone()
        {
            _boxCollider2D.enabled = false;
            
            _doorBottomSpriteRender.sprite = _doorBottomSprite;
            _doorTopSpriteRender.sprite = _doorTopSprite;
            
            _nextLevelObject.SetActive(true);
        }
    }
}