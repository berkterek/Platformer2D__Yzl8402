using UnityEngine;

namespace Platformer2d.Abstracts.ScriptableObjects
{
    public abstract class StatsSO : ScriptableObject
    {
        [Header("Movements")]
        [SerializeField] protected float _moveSpeed = 2f;
        
        [Header("Combats")] 
        [SerializeField] int _maxHealth = 100;
        [SerializeField] int _damage = 1;

        public virtual float MoveSpeed => _moveSpeed;
        public int MaxHealth => _maxHealth;
        public int Damage => _damage;
    }
}