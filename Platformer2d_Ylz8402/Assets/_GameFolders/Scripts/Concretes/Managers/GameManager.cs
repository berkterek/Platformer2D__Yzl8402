using System.Collections;
using System.Collections.Generic;
using Platformer2d.Abstracts.Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer2d.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        Dictionary<string, Vector3> _playerPositionByLevelName;

        public Vector3 LastPosition { get; set; }

        void Awake()
        {
            SingletonThisObject();
            _playerPositionByLevelName = new Dictionary<string, Vector3>();
        }

        public void LoadGameScene(string sceneName)
        {
            //Position not player => Doors Objective Start Points
            string currentSceneName = SceneManager.GetActiveScene().name;
            if (_playerPositionByLevelName.ContainsKey(currentSceneName))
            {
                _playerPositionByLevelName[currentSceneName] = LastPosition;
            }
            else
            {
                _playerPositionByLevelName.Add(currentSceneName,LastPosition); //Level1 son oyuncu pozisyonu
            }
            
            StartCoroutine(LoadGameSceneAsync(sceneName));

            // if (_playerPositionByLevelName.ContainsKey(sceneName))
            // {
            //     _playerPositionByLevelName[sceneName] = Vector3.zero;
            // }
            // else
            // {
            //     _playerPositionByLevelName.Add(sceneName,Vector3.zero); //Level2 ilk position    
            // }
        }

        private IEnumerator LoadGameSceneAsync(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }

        private void SingletonThisObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void SetPlayerLastPosition(IPlayerController playerController)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            if (_playerPositionByLevelName.ContainsKey(currentSceneName))
            {
                playerController.transform.position = _playerPositionByLevelName[currentSceneName];
            }
        }
    }    
}