using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorShrink : MonoBehaviour
{
      public float shrinkableDistance;
      public float distance;
      public Camera camera;


      private void OnDrawGizmos()
      {
            Gizmos.color = Color.yellow;
            Vector3 endPosition = transform.position + transform.forward * shrinkableDistance;
            Gizmos.DrawLine(transform.position, endPosition);
      }

      private void Update()
      {
            Ray();
            // Debug.Log(Vector3.Distance(transform.position, FindObjectOfType<ShrinkAndGrow>().transform.position));
      }
      private void Ray()
      {
            // Assuming the camera is attached to the same GameObject as this script


            // Ensure the camera component is not null
            if (camera != null)
            {
                  Ray ray = new Ray(camera.transform.position, camera.transform.forward);

                  // Check if the ray hits something within the specified distance
                  if (Physics.Raycast(ray, out RaycastHit hit, shrinkableDistance))
                  {
                        // Get the name of the hit object
                        if (hit.collider.CompareTag("ShrinkableDoor"))
                        {
                              Debug.Log(Vector3.Distance(camera.transform.position, hit.transform.position));
                              if (Vector3.Distance(camera.transform.position, FindObjectOfType<ShrinkAndGrow>().transform.position) < 3f && FindObjectOfType<ShrinkAndGrow>().transform.localScale.x == 100f)
                              {
                                    FindObjectOfType<ShrinkAndGrow>().isLooking = false;
                              }
                              else
                              {
                                    FindObjectOfType<ShrinkAndGrow>().isLooking = true;
                              }
                        }
                        else
                        {
                              FindObjectOfType<ShrinkAndGrow>().isLooking = false;
                        }

                        string hitObjectName = hit.collider.gameObject.name;

                        // Log or do something with the object's name
                        Debug.Log("Hit object: " + hitObjectName);
                  }
                  else
                  {
                        // Handle the case where the ray doesn't hit anything
                        FindObjectOfType<ShrinkAndGrow>().isLooking = false;
                  }
            }
      }
}
