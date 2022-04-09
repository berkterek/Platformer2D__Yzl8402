using System.Collections;
using Platformer2d.Abstracts.Controllers;
using Platformer2d.ScriptableObjects;
using UnityEngine;

namespace Platformer2d.Controllers
{
    public class ObjectiveObjectController : MonoBehaviour
    {
        [SerializeField] SpriteRenderer _spriteRenderer;
        [SerializeField] OpenCloseSaveLoadDataContainer _openCloseSaveLoad;

        IEnumerator Start()
        {
            if (_openCloseSaveLoad.IsOpen)
            {
                yield return new WaitForSecondsRealtime(3f);
                this.gameObject.SetActive(false);
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out IPlayerController playerController)) return;

            playerController.ObjectiveSpriteRenderer.sprite = _spriteRenderer.sprite;
            Destroy(this.gameObject);
        }
    }    
}

