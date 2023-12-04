using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour, IInteractable
{
      private Material objectMaterial;
      public KeyCode keyCode;
      public KeyCode interactKey => keyCode;

      private int colorCount;

      private void Start()
      {
            objectMaterial = GetComponent<Renderer>().material;
            objectMaterial.color = Color.green;
      }
      public void InteractMessage()
      {
            Debug.Log("Press " + keyCode + " to interact");
      }
      public void Interact()
      {
            ChangeColor();
      }

      private void ChangeColor()
      {
            if (colorCount % 2 == 0)
            {
                  objectMaterial.color = Color.red;
            }
            else
            {
                  objectMaterial.color = Color.green;
            }
            colorCount = colorCount % 2 + 1;
      }
}
