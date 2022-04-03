using Platformer2d.Abstracts.Controllers;
using UnityEngine;

namespace Platformer2d.Controllers
{
    public class CoinController : MonoBehaviour
    {
        [SerializeField] int _coinPoint = 1;

        void OnTriggerEnter2D(Collider2D other)
        {
            
            if (!other.TryGetComponent(out IPlayerController playerController)) return;
            
            //Collectable
        }
    }    
}