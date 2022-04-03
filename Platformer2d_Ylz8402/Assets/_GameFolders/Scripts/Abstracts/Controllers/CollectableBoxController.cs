using Platformer2d.Abstracts.Controllers;
using UnityEngine;

namespace Platformer2d.Abstracts.Controllers
{
    public abstract class CollectableBoxController : MonoBehaviour
    {
        [SerializeField] protected ParticleSystem _particle;
        [SerializeField] protected Sprite _endSprite;
        [SerializeField] protected int pointValue = 1;
        
        protected SpriteRenderer _spriteRenderer;
        protected Animator _animator;
        
        void Awake()
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _animator = GetComponent<Animator>();
        }
        
        void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.collider.TryGetComponent(out IPlayerController playerController)) return;
            if (other.contacts[0].normal.y != 1f) return;

            CollectedProcess(playerController);
        }

        protected abstract void CollectedProcess(IPlayerController playerController);
    }
}