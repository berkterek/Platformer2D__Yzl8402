using Platformer2d.Abstracts.Inputs;
using UnityEngine;

namespace Platformer2d.Inputs
{
    public class OldInputReader : IInputReader
    {
        public float Horizontal => Input.GetAxis("Horizontal");
        public bool IsJumpButtonPressed => Input.GetButtonDown("Jump");

        public OldInputReader()
        {
            Debug.Log($"Input System Name => {nameof(OldInputReader)}");
        }
    }    
}

