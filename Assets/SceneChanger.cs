using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
      private void OnTriggerEnter(Collider other)
      {
            if (other.transform.CompareTag("Player"))
            {
                  FindObjectOfType<SceneLoadManager>().SceneLoad("Scene2");
                  Debug.Log("Load Started");
                  Destroy(gameObject);
            }
      }
}
