using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer2d.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        void Awake()
        {
            SingletonThisObject();
        }

        public void LoadGameScene(string sceneName)
        {
            StartCoroutine(LoadGameSceneAsync(sceneName));
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
    }    
}