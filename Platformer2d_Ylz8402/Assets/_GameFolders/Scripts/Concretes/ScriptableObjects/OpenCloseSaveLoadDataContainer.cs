using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Is Open Close Save Load Data Container",menuName = "Bilge Adam/Data/Open Close Save Load Data Container")]
    public class OpenCloseSaveLoadDataContainer : ScriptableObject
    {
        [SerializeField] bool _isOpen = false;
        public bool IsOpen { get => _isOpen; set => _isOpen = value; }
    }
}
