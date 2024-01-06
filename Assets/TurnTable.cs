using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTable : MonoBehaviour
{
      private bool isTurning;
      private Quaternion targetRotation;
      public float rotationSpeed = 3.0f; // Adjust the speed as needed
      private void Turn()
      {
            Debug.Log("Turning");
            Quaternion currentRotation = transform.rotation;

            // Calculate the target rotation
            targetRotation = Quaternion.Euler(currentRotation.eulerAngles + new Vector3(0, 45, 0));

            // Start the rotation coroutine
            StartCoroutine(RotateObject(currentRotation, targetRotation));
      }

      private IEnumerator RotateObject(Quaternion startRotation, Quaternion endRotation)
      {
            float elapsedTime = 0f;

            while (elapsedTime < 1f)
            {
                  transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime);
                  elapsedTime += Time.deltaTime * rotationSpeed;

                  yield return null;
            }

            // Ensure the final rotation is exactly the target rotation
            transform.rotation = endRotation;

            // Signal that the turn is finished
            isTurning = false;
      }

      private void Update()
      {
            if (isTurning)
            {
                  // Perform the turn if it's in progress
                  Turn();
            }
      }

      public void StartTurn()
      {
            if (!isTurning)
            {
                  isTurning = true;
                  Debug.Log("Started");
            }
      }
}
