using Platformer2d.Abstracts.Animations;
using Platformer2d.Abstracts.Controllers;
using UnityEngine;

namespace Platformer2d.Animations
{
    public class PlayerAnimationWithAnimator : IAnimator
    {
        readonly Animator _animator;
        readonly IPlayerController _playerController;

        public PlayerAnimationWithAnimator(IPlayerController playerController)
        {
            _animator = playerController.transform.GetComponent<Animator>();
            _playerController = playerController;
        }

        public void LateTick()
        {
            MoveAnimation();
        }

        private void MoveAnimation()
        {
            float horizontal = Mathf.Abs(_playerController.InputReader.Horizontal);
            _animator.SetFloat("moveSpeed", horizontal);
        }
    }
}