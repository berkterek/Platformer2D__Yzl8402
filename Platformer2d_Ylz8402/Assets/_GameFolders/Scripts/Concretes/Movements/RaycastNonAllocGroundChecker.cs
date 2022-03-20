using UnityEngine;

namespace Platformer2d.Movements
{
    public class RaycastNonAllocGroundChecker : IGroundChecker
    {
        Transform[] _transforms;
        RaycastHit2D[] _hitResults;
        
        public bool IsOnGround { get; private set; }

        public RaycastNonAllocGroundChecker()
        {
            _hitResults = new RaycastHit2D[10];
        }
        
        public void FixedTick()
        {
            foreach (Transform transform in _transforms)
            {
                int resultCount = Physics2D.RaycastNonAlloc(
                    transform.position,
                    transform.forward,
                    _hitResults,
                    0.1f,
                );    
            }
        }
    }

    public interface IGroundChecker
    {
        bool IsOnGround { get; }
        void FixedTick();
    }
}