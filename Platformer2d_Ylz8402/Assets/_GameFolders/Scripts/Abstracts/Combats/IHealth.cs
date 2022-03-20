using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Abstracts.Combats
{
    public interface IHealth
    {
        void TakeDamage(IAttacker attacker);
        int MaxHealth { get; }
        int CurrentHealth { get; }
        event System.Action OnDead;
    }
}