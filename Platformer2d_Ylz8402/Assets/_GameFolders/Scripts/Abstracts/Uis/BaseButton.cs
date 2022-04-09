using UnityEngine;
using UnityEngine.UI;

namespace Platformer2d.Abstracts.Uis
{
    public abstract class BaseButton : MonoBehaviour
    {
        [SerializeField] Button _button;

        void Awake()
        {
            GetReference();
        }

        //bu method'un ozellegili sadece unity editor uzerinde calisir editor derlendikce calisir
        void OnValidate()
        {
            GetReference();
        }

        void OnEnable()
        {
            _button.onClick.AddListener(HandleOnButtonClicked);
        }

        void OnDisable()
        {
            _button.onClick.RemoveListener(HandleOnButtonClicked);
        }

        protected abstract void HandleOnButtonClicked();

        private void GetReference()
        {
            if (_button == null)
            {
                _button = GetComponent<Button>();
            }
        }
    }
}