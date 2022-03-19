using Platformer2d.Abstracts.Controllers;
using Platformer2d.Abstracts.Inputs;
using Platformer2d.Inputs;
using UnityEngine;

namespace Platformer2d.Controllers
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        [SerializeField] float _moveSpeed = 1f;

        IInputReader _inputReader;

        void Awake()
        {
            _inputReader = new NewInputReader();
        }

        void Update()
        {
        }

        void FixedUpdate()
        {
        }
    }
}