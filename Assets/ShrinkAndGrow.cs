using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkAndGrow : MonoBehaviour
{
      [SerializeField] private Transform upWall;
      [SerializeField] private Transform leftWall;
      [SerializeField] private Transform rightWall; // Adjust this factor for the rate of growth

      public float resizeSpeed = 1.0f;

      // Update is called once per frame
      void Update()
      {
            LeftWallScale();
            RightWallScale();
            UpWallScale();
      }

      private void LeftWallScale()
      {
            Vector3 currentScale = leftWall.localScale;
            currentScale.y += 5f * resizeSpeed * Time.deltaTime;
            leftWall.localScale = currentScale;
      }
      private void RightWallScale()
      {
            Vector3 currentScale = rightWall.localScale;
            currentScale.y += 5f * resizeSpeed * Time.deltaTime;
            rightWall.localScale = currentScale;
      }
      private void UpWallScale()
      {
            Vector3 currentScale = upWall.localScale;
            currentScale.z += 5f * resizeSpeed * Time.deltaTime;
            upWall.localScale = currentScale;

      }
}
