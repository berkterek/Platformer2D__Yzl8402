using Platformer2d.Abstracts.Controllers;
using Platformer2d.Managers;
using UnityEngine;

namespace Platformer2d.Controllers
{
    public class NextLevelObjectController : MonoBehaviour
    {
        [SerializeField] string _levelName;
        [SerializeField] BoxCollider2D _boxCollider2D;
        [SerializeField] Transform _objectiveStartPoint;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out IPlayerController playerController)) return;
            _boxCollider2D.enabled = false;

            GameManager.Instance.LastPosition = _objectiveStartPoint.position;
            GameManager.Instance.LoadGameSceneOnGameplay(_levelName);
        }
    }    
}