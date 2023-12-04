using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
      KeyCode interactKey { get; }
      public void Interact();
      public void InteractMessage();
}
public class PlayerInteractor : MonoBehaviour
{
      public Transform interactorSource;
      public float interactRange;
      public LayerMask interactableLayer;
      private IInteractable lastInteractedObject;

      private void Update()
      {
            Ray r = new Ray(interactorSource.position, interactorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange, interactableLayer))
            {
                  if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                  {
                        if (interactObj != lastInteractedObject)
                        {
                              interactObj.InteractMessage();
                              lastInteractedObject = interactObj;
                        }

                        if (Input.GetKeyDown(interactObj.interactKey))
                        {
                              interactObj.Interact();
                        }
                  }
                  else
                  {
                        // If not looking at an interactable object, reset the lastInteractedObject
                        lastInteractedObject = null;
                  }
            }
            else
            {
                  // If the ray doesn't hit anything, reset the lastInteractedObject
                  lastInteractedObject = null;
            }
      }
}
