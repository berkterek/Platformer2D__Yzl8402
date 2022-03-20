using Platformer2d.Abstracts.Combats;
using UnityEngine;

namespace Platformer2d.Combats
{
    public class Health : IHealth
    {
        public int MaxHealth { get; }
        public int CurrentHealth { get; private set; }
        bool IsDead => CurrentHealth <= 0;        
        public event System.Action OnDead;

        public Health()
        {
            MaxHealth = 100;
            CurrentHealth = MaxHealth;
        }
        
        public void TakeDamage(IAttacker attacker)
        {
            if (IsDead) return;
            
            CurrentHealth = Mathf.Max(CurrentHealth -= attacker.Damage,0);
            
            if (IsDead)
            {
                OnDead?.Invoke();    
            }
        }
    }    
}

