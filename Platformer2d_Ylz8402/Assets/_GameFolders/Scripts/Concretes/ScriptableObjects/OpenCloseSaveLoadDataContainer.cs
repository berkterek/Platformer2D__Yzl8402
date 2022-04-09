using UnityEngine;

namespace Platformer2d.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Is Open Close Save Load Data Container",menuName = "Bilge Adam/Data/Open Close Save Load Data Container")]
    public class OpenCloseSaveLoadDataContainer : ScriptableObject
    {
        [SerializeField] bool _isOpen = false;
        public bool IsOpen { get => _isOpen; set => _isOpen = value; }
        

        void OnEnable()
        {
            string value = PlayerPrefs.GetString(this.name);
            if (!string.IsNullOrEmpty(value))
            {
                _isOpen = bool.Parse(value);
            }
            
#if UNITY_EDITOR
            _isOpen = false;
#endif
        }


        void OnDisable()
        {
            PlayerPrefs.SetString(this.name,_isOpen.ToString());
        }
    }
}
