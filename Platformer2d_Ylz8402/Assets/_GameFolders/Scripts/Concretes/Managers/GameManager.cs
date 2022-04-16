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

        public void LoadMenuScene()
        {
            StartCoroutine(LoadMenuSceneAsync());
        }

        public void StartGame()
        {
            StartCoroutine(LoadStartGameAsync());
        }
        
        public void LoadGameSceneOnGameplay(string sceneName)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            if (_playerPositionByLevelName.ContainsKey(currentSceneName))
            {
                _playerPositionByLevelName[currentSceneName] = LastPosition;
            }
            else
            {
                _playerPositionByLevelName.Add(currentSceneName, LastPosition);
            }

            StartCoroutine(LoadGameSceneOnGameplayAsync(sceneName, currentSceneName));
        }

        private IEnumerator LoadGameSceneOnGameplayAsync(string newScene, string oldScene)
        {
            Scene uiScene = SceneManager.GetSceneByName("Ui");
            SceneManager.SetActiveScene(uiScene);

            yield return SceneManager.UnloadSceneAsync(oldScene);
            
            yield return SceneManager.LoadSceneAsync(newScene, LoadSceneMode.Additive);
            Scene newActiveScene = SceneManager.GetSceneByName(newScene);
            SceneManager.SetActiveScene(newActiveScene);
        }

        private IEnumerator LoadStartGameAsync()
        {
            Scene activeScene = SceneManager.GetActiveScene();
            
            Scene uiScene = SceneManager.GetSceneByName("Ui");

            if (!uiScene.IsValid())
            {
                yield return SceneManager.LoadSceneAsync("Ui", LoadSceneMode.Additive);
                uiScene = SceneManager.GetSceneByName("Ui");
            }
            
            SceneManager.SetActiveScene(uiScene);
            
            yield return SceneManager.UnloadSceneAsync(activeScene);
            
            yield return SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive);
            
            Scene level1ActiveScene = SceneManager.GetSceneByName("Level1");
            SceneManager.SetActiveScene(level1ActiveScene);
        }
        
        IEnumerator LoadMenuSceneAsync()
        {
            yield return SceneManager.LoadSceneAsync("Menu");
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

        public void ExitGame()
        {
            Debug.Log("Exit Game");
            Application.Quit();
        }

        public void DeleteLoadingData()
        {
            Debug.Log("Deleting all loading data");
            PlayerPrefs.DeleteAll();
        }
    }
}