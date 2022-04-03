using Platformer2d.Abstracts.Controllers;
using UnityEngine;

namespace Platformer2d.Controllers
{
    public class CoinController : MonoBehaviour
    {
        [SerializeField] int _coinPoint = 1;
        [SerializeField] GameObject vfx;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out IPlayerController playerController)) return;
            
            playerController.IncreaseCoin(_coinPoint);
            vfx.transform.parent = null;
            vfx.SetActive(true);
            Destroy(this.gameObject);
        }
    }    
}