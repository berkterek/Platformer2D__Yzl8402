using Platformer2d.Abstracts.Controllers;
using UnityEngine;

namespace Platformer2d.Controllers
{
    public class KeyChestController : MonoBehaviour
    {
        Animator _animator;
        Collider2D _collider2D;

        void Awake()
        {
            _animator = GetComponent<Animator>();
            _collider2D = GetComponent<Collider2D>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out IPlayerController playerController)) return;
            
            _animator.SetTrigger("open");
            _collider2D.enabled = false;
        }
    }
}