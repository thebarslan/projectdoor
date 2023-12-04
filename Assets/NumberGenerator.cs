using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberGenerator : MonoBehaviour, IInteractable
{
      public KeyCode keyCode;
      public KeyCode interactKey => keyCode;
      public void InteractMessage()
      {
            Debug.Log("Press " + keyCode + " to interact");
      }
      public void Interact()
      {
            Debug.Log(Random.Range(0, 100));
      }
}
