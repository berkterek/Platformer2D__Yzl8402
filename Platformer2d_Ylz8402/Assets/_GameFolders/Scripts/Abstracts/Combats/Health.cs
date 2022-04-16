using Platformer2d.Abstracts.DataContainers;
using UnityEngine;

namespace Platformer2d.Abstracts.Combats
{
    public abstract class Health : IHealth
    {
        public int MaxHealth { get; protected set; }
        public int CurrentHealth { get; protected set; }
        bool IsDead => CurrentHealth <= 0;
        public event System.Action OnDead;
        public event System.Action OnTookHit;

        protected Health(IStats stats)
        {
            SetHealthInfo(stats);
        }

        protected virtual void SetHealthInfo(IStats stats)
        {
            MaxHealth = stats.MaxHealth;
            CurrentHealth = MaxHealth;
        }

        public virtual void TakeDamage(IAttacker attacker)
        {
            if (IsDead) return;

            CurrentHealth = Mathf.Max(CurrentHealth -= attacker.Damage, 0);

            if (IsDead)
            {
                DeadProcess();
            }
            else
            {
                OnTookHit?.Invoke();
            }
        }

        protected virtual void DeadProcess()
        {
            OnDead?.Invoke();
        }

        public virtual void IncreaseHealth(int healthValue)
        {
            CurrentHealth = Mathf.Min(CurrentHealth + healthValue, MaxHealth);
            Debug.Log(CurrentHealth);
        }
    }
}