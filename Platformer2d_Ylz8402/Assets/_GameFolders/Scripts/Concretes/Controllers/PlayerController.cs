using Platformer2d.Abstracts.Controllers;
using UnityEngine;

namespace Platformer2d.Controllers
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        [SerializeField] float _moveSpeed = 1f;
        
        Transform _transform;
        float _horizontal;

        void Awake()
        {
            _transform = transform;
        }

        void Update()
        {
            _horizontal = Input.GetAxis("Horizontal");
        }

        void FixedUpdate()
        {
            _transform.Translate(Vector3.right * _horizontal * Time.deltaTime * _moveSpeed);
        }
    }
}