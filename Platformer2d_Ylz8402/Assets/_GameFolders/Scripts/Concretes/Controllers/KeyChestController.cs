using Platformer2d.Abstracts.Controllers;
using Platformer2d.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace Platformer2d.Controllers
{
    public class KeyChestController : MonoBehaviour
    {
        [SerializeField] OpenCloseSaveLoadDataContainer _openCloseSaveLoad;
        [SerializeField] TMP_Text _purchaseValueText;
        [SerializeField] int _purchaseValue = 10;
        
        Animator _animator;
        Collider2D _collider2D;

        void Awake()
        {
            _animator = GetComponent<Animator>();
            _collider2D = GetComponent<Collider2D>();
        }
        
        void OnEnable()
        {
            if (_openCloseSaveLoad.IsOpen)
            {
                ObjectiveDone();
            }
        }

        void Start()
        {
            _purchaseValueText.text = _purchaseValue.ToString();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out IPlayerController playerController)) return;

            if (playerController.DecreaseCoin(_purchaseValue))
            {
                ObjectiveDone();
            }
            else
            {
                Debug.Log("You dont have enough coin");
            }
        }
        
        void ObjectiveDone()
        {
            _animator.SetTrigger("open");
            _collider2D.enabled = false;
        }
    }
}