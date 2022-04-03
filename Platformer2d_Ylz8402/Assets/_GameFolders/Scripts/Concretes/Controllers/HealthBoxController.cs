using Platformer2d.Abstracts.Controllers;

namespace Platformer2d.Controllers
{
    public class HealthBoxController : CollectableBoxController
    {
        bool _isPlayOneTime = false;

        protected override void CollectedProcess(IPlayerController playerController)
        {
            if (_isPlayOneTime) return;
            
            playerController.Health.IncreaseHealth(_pointValue);
            _animator.SetTrigger("collected");
            _particle.Play();
            _spriteRenderer.sprite = _endSprite;
            _isPlayOneTime = true;
        }
    }
}