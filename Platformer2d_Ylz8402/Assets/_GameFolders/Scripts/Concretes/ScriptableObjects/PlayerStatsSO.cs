using Platformer2d.Abstracts.DataContainers;
using UnityEngine;

namespace Platformer2d.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player Stats",menuName = "Bilge Adam/Stats/Player Stats")]
    public class PlayerStatsSO : ScriptableObject, IPlayerStats
    {
        [Header("Movements")]
        [SerializeField] float _moveSpeed = 2f;
        [SerializeField] float _jumpForce = 5000f;
        [SerializeField] int _maxJumpCount = 2;
        
        [Header("Combats")]
        [SerializeField] int _maxHealth = 100;

        public float MoveSpeed => _moveSpeed;
        public float JumpForce => _jumpForce;
        public int MaxJumpCount => _maxJumpCount;
        public int MaxHealth => _maxHealth;
    }
}