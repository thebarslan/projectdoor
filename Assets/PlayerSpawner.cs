using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
      public List<PlayerPositionRotation> playerPosRotList = new List<PlayerPositionRotation>();

      private void Start()
      {
            playerPosRotList.Clear();
            DontDestroyOnLoad(gameObject);
      }

      public void AddPlayerPosRot(PlayerPositionRotation playerPosRot)
      {
            playerPosRotList.Add(playerPosRot);
      }

      public PlayerPositionRotation GetPlayerPosRot(string sceneName)
      {
            return playerPosRotList.Find(item => item.sceneName == sceneName);
      }

}
