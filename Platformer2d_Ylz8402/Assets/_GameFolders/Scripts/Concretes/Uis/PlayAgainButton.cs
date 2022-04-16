using Platformer2d.Abstracts.Uis;
using Platformer2d.Managers;
using UnityEngine;

namespace Platformer2d.Uis
{
    public class PlayAgainButton : BaseButton
    {
        [SerializeField] GameObject _gameOverPanel;
        
        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.StartGame();
            _gameOverPanel.SetActive(false);
        }
    }
}

