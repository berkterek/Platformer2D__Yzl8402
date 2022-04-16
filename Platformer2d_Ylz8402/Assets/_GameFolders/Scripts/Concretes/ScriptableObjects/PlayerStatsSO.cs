using Platformer2d.Abstracts.DataContainers;
using UnityEngine;

namespace Platformer2d.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player Stats", menuName = "Bilge Adam/Stats/Player Stats")]
    public class PlayerStatsSO : EnemyStatsSO, IPlayerStats
    {
        [Header("Movements")] 
        [SerializeField] float _jumpForce = 5000f;
        [SerializeField] int _maxJumpCount = 2;

        public float JumpForce => _jumpForce;
        public int MaxJumpCount => _maxJumpCount;
    }
}