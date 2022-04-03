using Platformer2d.Abstracts.Controllers;
using UnityEngine;

namespace Platformer2d.Controllers
{
    public class BoxCoinController : CollectableBoxController
    {
        [SerializeField] int _counter = 5;

        protected override void CollectedProcess(IPlayerController playerController)
        {
            _counter--;

            if (_counter > 0)
            {
                playerController.IncreaseCoin(pointValue);
                _animator.SetTrigger("collected");
                _particle.Play();
            }
            else if (_counter == 0)
            {
                playerController.IncreaseCoin(pointValue);
                _spriteRenderer.sprite = _endSprite;
            }
        }
    }
}