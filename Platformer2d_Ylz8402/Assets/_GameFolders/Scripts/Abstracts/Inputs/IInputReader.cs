using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Abstracts.Inputs
{
    public interface IInputReader
    {
        float Horizontal { get; }
        bool IsJumpButtonPressed { get; }
    }    
}

