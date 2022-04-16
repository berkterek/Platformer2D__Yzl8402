using Platformer2d.Abstracts.DataContainers;
using UnityEngine;

namespace Platformer2d.Abstracts.Combats
{
    public abstract class Health : IHealth
    {
        public int MaxHealth { get; }
        public int CurrentHealth { get; private set; }
        bool IsDead => CurrentHealth <= 0;        
        public event System.Action OnDead;
        public event System.Action OnTookHit;

        protected Health(IStats stats)
        {
            MaxHealth = stats.MaxHealth;
            CurrentHealth = MaxHealth;
        }
        
        public virtual void TakeDamage(IAttacker attacker)
        {
            if (IsDead) return;
            
            CurrentHealth = Mathf.Max(CurrentHealth -= attacker.Damage,0);
            
            if (IsDead)
            {
                OnDead?.Invoke();    
            }
            else
            {
                OnTookHit?.Invoke();
            }
        }
        
        public virtual void IncreaseHealth(int healthValue)
        {
            CurrentHealth = Mathf.Min(CurrentHealth + healthValue, MaxHealth);
            Debug.Log(CurrentHealth);
        }
    }
}

