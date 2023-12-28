using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{

      public KeyCode keyCode;
      public KeyCode interactKey => keyCode;
      [SerializeField] public float movementSpeed;
      [SerializeField] private Quaternion startPos;
      [SerializeField] private Quaternion destination;
      private bool isMoving;
      private int moveCount;

      private void Start()
      {
            startPos = transform.localRotation;
      }


      public string GetInteractMessage()
      {
            return "Press " + keyCode + " to interact";
      }
      public void Interact()
      {
            if (!isMoving)
            {
                  startPos = transform.localRotation;
                  SetDestination();
                  StartCoroutine(MoveObject());
            }
      }

      private void SetDestination()
      {
            if (moveCount % 2 == 0)
            {
                  destination = Quaternion.Euler(startPos.eulerAngles + new Vector3(0, 0, -90f));
            }
            else
            {
                  destination = Quaternion.Euler(startPos.eulerAngles + new Vector3(0, 0, +90f));
            }
            moveCount = moveCount % 2 + 1;
      }

      private IEnumerator MoveObject()
      {
            isMoving = true;
            float elapsedTime = 0f;

            while (elapsedTime < 1 / movementSpeed)
            {
                  transform.localRotation = Quaternion.Lerp(startPos, destination, elapsedTime / (1 / movementSpeed));
                  elapsedTime += Time.deltaTime;
                  yield return null;
            }

            transform.localRotation = destination;
            isMoving = false;
      }
}
