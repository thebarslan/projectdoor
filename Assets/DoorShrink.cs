using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorShrink : MonoBehaviour
{
      public float shrinkableDistance;
      public float distance;


      private void OnDrawGizmos()
      {
            Gizmos.color = Color.yellow;
            Vector3 endPosition = transform.position + transform.forward * shrinkableDistance;
            Gizmos.DrawLine(transform.position, endPosition);
      }

      private void Update()
      {
            Ray();
      }
      private void Ray()
      {
            Ray ray = new Ray(transform.position, transform.forward);

            // Check if the ray hits something within the specified distance
            if (Physics.Raycast(ray, out RaycastHit hit, shrinkableDistance))
            {
                  // Get the name of the hit object
                  string hitObjectName = hit.collider.gameObject.name;

                  // Log or do something with the object's name
                  Debug.Log("Hit object: " + hitObjectName);
            }
      }
}
