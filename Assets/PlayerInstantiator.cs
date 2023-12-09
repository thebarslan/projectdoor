using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerInstantiator : MonoBehaviour
{
      private PlayerSpawner playerSpawner;
      public GameObject playerPrefab; // Assign your player prefab in the Inspector

      private void Start()
      {
            playerSpawner = FindObjectOfType<PlayerSpawner>();
            PlayerPositionRotation playerPosRot = playerSpawner.GetPlayerPosRot(FindObjectOfType<SceneLoadManager>().currentSceneName);

            if (playerPosRot != null)
            {
                  GameObject player = Instantiate(playerPrefab, playerPosRot.position, playerPosRot.rotation);
                  // Set up any additional player initialization logic if needed

            }
      }
}
