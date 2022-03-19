using Platformer2d.Abstracts.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer2d.Inputs
{
    public class NewInputReader : IInputReader
    {
        readonly GameInputActions _inputAction;

        public float Horizontal { get; private set; }
        public bool IsJumpButtonPressed => _inputAction.Player.Jump.WasPressedThisFrame();

        public NewInputReader()
        {
            Debug.Log($"Input System Name => {nameof(NewInputReader)}");

            _inputAction = new GameInputActions();

            _inputAction.Player.HorizontalMove.performed += HandleOnHorizontalMove;
            _inputAction.Player.HorizontalMove.canceled += HandleOnHorizontalMove;

            _inputAction.Enable();
        }

        void HandleOnHorizontalMove(InputAction.CallbackContext context)
        {
            Horizontal = context.ReadValue<float>();
        }
    }
}