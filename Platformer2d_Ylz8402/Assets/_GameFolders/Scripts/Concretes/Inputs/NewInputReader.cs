using Platformer2d.Abstracts.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer2d.Inputs
{
    public class NewInputReader : IInputReader
    {
        public float Horizontal { get; private set; }

        public NewInputReader()
        {
            Debug.Log($"Input System Name => {nameof(NewInputReader)}");
            
            GameInputActions inputAction = new GameInputActions();
            
            inputAction.Player.HorizontalMove.performed += HandleOnHorizontalMove;
            inputAction.Player.HorizontalMove.canceled += HandleOnHorizontalMove;
            
            inputAction.Enable();
        }

        void HandleOnHorizontalMove(InputAction.CallbackContext context)
        {
            Horizontal = context.ReadValue<float>();
        }
    }    
}

