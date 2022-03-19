using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Abstracts.Movements
{
    public interface IMover
    {
        void Tick();
        void FixedTick();
    }    
}

