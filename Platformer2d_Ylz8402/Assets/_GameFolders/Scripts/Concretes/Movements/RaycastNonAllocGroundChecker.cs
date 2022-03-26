using Platformer2d.Abstracts.Movements;
using UnityEngine;

namespace Platformer2d.Movements
{
    public class RaycastNonAllocGroundChecker : MonoBehaviour, IGroundChecker
    {
        [SerializeField] bool _isOnGround;
        [SerializeField] LayerMask _layerMask;
        [SerializeField] Transform[] _transforms;

        RaycastHit2D[] _hitResults;

        public bool IsOnGround => _isOnGround;

        void Awake()
        {
            _hitResults = new RaycastHit2D[10];
        }

        void FixedUpdate()
        {
            FixedTick();
        }

        public void FixedTick()
        {
            foreach (Transform footTransform in _transforms)
            {
                int resultCount = Physics2D.RaycastNonAlloc(
                    footTransform.position,
                    footTransform.forward,
                    _hitResults,
                    0.1f,
                    _layerMask
                );
                
#if UNITY_EDITOR
                Debug.DrawRay(footTransform.position, footTransform.forward * 0.1f, Color.red);
#endif

                if (resultCount != 0)
                {
                    _isOnGround = true;
                    return;
                }
            }

            _isOnGround = false;
        }
    }
}