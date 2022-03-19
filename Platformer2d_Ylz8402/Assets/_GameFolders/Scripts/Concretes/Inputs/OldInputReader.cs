using System.Collections;
using System.Collections.Generic;
using Platformer2d.Abstracts.Inputs;
using UnityEngine;

namespace Platformer2d.Inputs
{
    public class OldInputReader : IInputReader
    {
        public float Horizontal => Input.GetAxis("Horizontal");

        public OldInputReader()
        {
            Debug.Log($"Input System Name => {nameof(OldInputReader)}");
        }
    }    
}

