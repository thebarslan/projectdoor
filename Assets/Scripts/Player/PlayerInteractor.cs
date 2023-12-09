using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

interface IInteractable
{
      KeyCode interactKey { get; }
      public void Interact();
      string GetInteractMessage();
}
public class PlayerInteractor : MonoBehaviour
{
      public Transform interactorSource;
      public float interactRange;
      public LayerMask interactableLayer;
      private IInteractable lastInteractedObject;

      [SerializeField] private TextMeshProUGUI interactMessageText;

      private void Update()
      {
            Ray r = new Ray(interactorSource.position, interactorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange, interactableLayer))
            {
                  if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                  {
                        if (interactObj != lastInteractedObject)
                        {
                              ShowInteractMessage(interactObj.GetInteractMessage());
                              lastInteractedObject = interactObj;
                        }

                        if (Input.GetKeyDown(interactObj.interactKey))
                        {
                              interactObj.Interact();
                              HideInteractMessage();
                        }
                  }
                  else
                  {
                        // If not looking at an interactable object, reset the lastInteractedObject
                        lastInteractedObject = null;
                        HideInteractMessage();
                  }
            }
            else
            {
                  // If the ray doesn't hit anything, reset the lastInteractedObject
                  lastInteractedObject = null;
                  HideInteractMessage();
            }
      }

      private void ShowInteractMessage(string message)
      {
            interactMessageText.text = message;
            interactMessageText.gameObject.SetActive(true);
      }

      private void HideInteractMessage()
      {
            interactMessageText.gameObject.SetActive(false);
      }
}
