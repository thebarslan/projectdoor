using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour, IInteractable
{
      private Material objectMaterial;
      public KeyCode keyCode;
      public KeyCode interactKey => keyCode;
      [SerializeField] public float moveDistance;
      [SerializeField] public float movementSpeed;
      private Vector3 startPos;
      private Vector3 destination;
      private bool isMoving;

      private int moveCount;

      private void Start()
      {
            startPos = transform.position;
      }

      public void InteractMessage()
      {
            Debug.Log("Press " + keyCode + " to interact");
      }

      public void Interact()
      {
            if (!isMoving)
            {
                  startPos = transform.position;
                  SetDestination();
                  StartCoroutine(MoveObject());
            }
      }

      private void SetDestination()
      {
            if (moveCount % 2 == 0)
            {
                  destination = startPos + new Vector3(0, moveDistance, 0);
            }
            else
            {
                  destination = startPos + new Vector3(0, -moveDistance, 0);
            }
            moveCount = moveCount % 2 + 1;
      }

      private IEnumerator MoveObject()
      {
            isMoving = true;
            float elapsedTime = 0f;

            while (elapsedTime < 1 / movementSpeed)
            {
                  transform.position = Vector3.Lerp(startPos, destination, elapsedTime / (1 / movementSpeed));
                  elapsedTime += Time.deltaTime;
                  yield return null;
            }

            transform.position = destination;
            isMoving = false;
      }
}
