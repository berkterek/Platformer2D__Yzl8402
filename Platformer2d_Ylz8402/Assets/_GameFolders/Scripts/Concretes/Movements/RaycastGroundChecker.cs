using Platformer2d.Abstracts.Movements;
using UnityEngine;

namespace Platformer2d.Movements
{
    public class RaycastGroundChecker : MonoBehaviour, IGroundChecker
    {
        [SerializeField] bool _isOnGround;
        [SerializeField] float _groundCheckDistance = 0.5f;
        [SerializeField] Transform _groundCheckTransform;
        [SerializeField] LayerMask _layerMask;

        public bool IsOnGround => _isOnGround;

        void FixedUpdate()
        {
            FixedTick();
        }

        public void FixedTick()
        {
            _isOnGround = Physics2D.Raycast(_groundCheckTransform.position, _groundCheckTransform.forward,
                _groundCheckDistance,
                _layerMask);
        }
    }
}