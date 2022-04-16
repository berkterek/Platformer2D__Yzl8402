using Platformer2d.ScriptableObjects;
using UnityEngine;

namespace Platformer2d.Controllers.Uis
{
    public class GameOverObjectController : MonoBehaviour
    {
        [SerializeField] GameObject _childObject;
        [SerializeField] StringEventWithOneParameterSO _dyingEvent;

        void Awake()
        {
            GetReference();
        }

        void OnValidate()
        {
            GetReference();
        }

        void OnEnable()
        {
            _dyingEvent.OnIntEventOneParameterTriggered += HandleOnDead;
        }

        void OnDisable()
        {
            _dyingEvent.OnIntEventOneParameterTriggered -= HandleOnDead;
        }

        void GetReference()
        {
            if (_childObject == null)
            {
                _childObject = this.transform.GetChild(0).gameObject;
            }
        }
        
        void HandleOnDead(string message)
        {
            Debug.Log(message);
            _childObject.SetActive(true);
        }
    }    
}