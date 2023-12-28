using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkAndGrow : MonoBehaviour
{
      [SerializeField] private Transform upWall;
      [SerializeField] private Transform leftWall;
      [SerializeField] private Transform rightWall; // Adjust this factor for the rate of growth
      public bool isLooking = false;
      public float resizeSpeed = 1.0f;

      private Vector3 upWallScale, leftWallScale, rightWallScale;

      // Update is called once per frame

      private void Start()
      {
            upWallScale = upWall.localScale;
            leftWallScale = leftWall.localScale;
            rightWallScale = rightWall.localScale;
      }
      void FixedUpdate()
      {
            ShrinkWalls();
            GrowWalls();
      }

      private void ShrinkWalls()
      {
            if (isLooking && transform.localScale.x >= 40f)
            {
                  leftWall.transform.localScale = new Vector3(leftWall.transform.localScale.x, leftWall.transform.localScale.y + (resizeSpeed), leftWall.transform.localScale.z);
                  rightWall.transform.localScale = new Vector3(rightWall.transform.localScale.x, rightWall.transform.localScale.y + (resizeSpeed), rightWall.transform.localScale.z);
                  upWall.transform.localScale = new Vector3(upWall.transform.localScale.x, upWall.transform.localScale.y - (2.3f * resizeSpeed), upWall.transform.localScale.z + (14.4f * resizeSpeed));
                  transform.localScale = new Vector3(transform.localScale.x - (2.5f * resizeSpeed), transform.localScale.y - (2.5f * resizeSpeed), transform.localScale.z - (2.5f * resizeSpeed));
            }
      }
      private void GrowWalls()
      {
            if (!isLooking && transform.localScale.x < 100f)
            {
                  leftWall.transform.localScale = new Vector3(leftWall.transform.localScale.x, leftWall.transform.localScale.y - (resizeSpeed), leftWall.transform.localScale.z);
                  rightWall.transform.localScale = new Vector3(rightWall.transform.localScale.x, rightWall.transform.localScale.y - (resizeSpeed), rightWall.transform.localScale.z);
                  upWall.transform.localScale = new Vector3(upWall.transform.localScale.x, upWall.transform.localScale.y + (2.3f * resizeSpeed), upWall.transform.localScale.z - (14.4f * resizeSpeed));
                  transform.localScale = new Vector3(transform.localScale.x + (2.5f * resizeSpeed), transform.localScale.y + (2.5f * resizeSpeed), transform.localScale.z + (2.5f * resizeSpeed));
            }
      }
}
