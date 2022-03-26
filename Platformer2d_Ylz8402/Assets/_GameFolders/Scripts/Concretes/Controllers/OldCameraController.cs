using UnityEngine;

namespace Platformer2d.Controllers
{
    public class OldCameraController : MonoBehaviour
    {
        [SerializeField] float _zPosition = -10f;
        [SerializeField] Transform _followTarget;

        Transform _currentTransform;

        void Awake()
        {
            _currentTransform = transform;
        }

        void LateUpdate()
        {
            Vector3 followTargetPosition = _followTarget.position;
            _currentTransform.position = new Vector3(followTargetPosition.x,followTargetPosition.y,_zPosition);
        }
    }    
}

