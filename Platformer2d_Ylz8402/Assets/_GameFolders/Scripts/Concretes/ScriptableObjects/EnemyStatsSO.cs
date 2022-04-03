using Platformer2d.Abstracts.DataContainers;
using Platformer2d.Abstracts.ScriptableObjects;
using UnityEngine;

namespace Platformer2d.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Enemy Stats", menuName = "Bilge Adam/Stats/Enemy Stats")]
    public class EnemyStatsSO : StatsSO, IEnemyStats
    {
        [Header("Movements")]
        [SerializeField] float _maxMoveSpeed = 4f;

        public override float MoveSpeed => Random.Range(_moveSpeed, _maxMoveSpeed);
    }
}