using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorGateOpener : MonoBehaviour, IInteractable

{
      public KeyCode keyCode;
      public KeyCode interactKey => keyCode;

      private Vector3 startPos, destination;
      private SkinnedMeshRenderer skinnedMeshRenderer;
      public string blendShapeName = "Cube.003";
      public float blendShapeTargetValue = 100.0f;
      public float blendShapeChangeSpeed = 2.0f;
      public Transform elevatorGate;
      private bool isMoving;

      private int moveCount;
      [SerializeField] public float movementSpeed;
      private void Start()
      {
            startPos = elevatorGate.position;
            skinnedMeshRenderer = elevatorGate.GetComponent<SkinnedMeshRenderer>();

      }

      // Start is called before the first frame update

      public void Interact()
      {
            if (!isMoving)
            {
                  SetDestination();
                  StartCoroutine(MoveObject());
            }
      }
      private void SetDestination()
      {
            if (moveCount % 2 == 0)
            {
                  destination = startPos + new Vector3(0, 0, +1.5f);
            }
            else
            {
                  destination = startPos;
            }

            moveCount = moveCount % 2 + 1;
      }
      public string GetInteractMessage()
      {
            return "Press " + keyCode + " to interact";
      }

      private IEnumerator MoveObject()
      {
            isMoving = true;
            float elapsedTime = 0f;

            while (elapsedTime < 1 / movementSpeed)
            {
                  elevatorGate.transform.position = Vector3.Lerp(startPos, destination, elapsedTime / (1 / movementSpeed));
                  UpdateBlendShape();
                  elapsedTime += Time.deltaTime;
                  yield return null;
            }

            isMoving = false;
      }
      private void UpdateBlendShape()
      {
            if (skinnedMeshRenderer == null)
            {
                  Debug.LogError("SkinnedMeshRenderer not assigned!");
                  return;
            }

            // BlendShape değerini yavaşça değiştirme
            float currentBlendShapeValue = skinnedMeshRenderer.GetBlendShapeWeight(skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(blendShapeName));
            float newBlendShapeValue = Mathf.Lerp(currentBlendShapeValue, blendShapeTargetValue, blendShapeChangeSpeed * Time.deltaTime);
            skinnedMeshRenderer.SetBlendShapeWeight(skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(blendShapeName), newBlendShapeValue);
      }
}
