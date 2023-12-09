using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
      [SerializeField] private TextMeshProUGUI loadingText;
      private PlayerSpawner playerSpawner;
      public string currentSceneName;

      private void Start()
      {
            DontDestroyOnLoad(gameObject);
            playerSpawner = FindObjectOfType<PlayerSpawner>();
      }
      public void SceneLoad(string sceneName)
      {
            PlayerPositionRotation playerPosRot = new PlayerPositionRotation();
            playerPosRot.sceneName = SceneManager.GetActiveScene().name;
            currentSceneName = playerPosRot.sceneName;
            playerPosRot.position = FindObjectOfType<PlayerInteractor>().gameObject.transform.position;
            playerPosRot.rotation = FindObjectOfType<PlayerInteractor>().gameObject.transform.rotation;
            playerSpawner.AddPlayerPosRot(playerPosRot);
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

            loadingText.text = "Auto Saving";
            // Sahne yüklemesi tamamlanana kadar bekle
            StartCoroutine(WaitAndContinue(asyncOperation));
      }

      IEnumerator WaitAndContinue(AsyncOperation asyncOperation)
      {
            // Sahne yüklemesi tamamlanana kadar bekleyin
            while (!asyncOperation.isDone)
            {
                  yield return null;
            }

            // Oyunu devam ettirin veya başka bir şey yapın
            loadingText.text = "";
            Debug.Log("Sahne geçişi tamamlandı. Oyun devam ediyor...");
      }
}
