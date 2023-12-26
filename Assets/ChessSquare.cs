using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessSquare : MonoBehaviour
{
      public void SetMaterial(bool isWhite)
      {
            GetComponent<Renderer>().material.color = isWhite ? Color.white : Color.black;
      }
}
