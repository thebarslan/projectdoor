using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessButton : MonoBehaviour, IInteractable
{
      public KeyCode keyCode;
      public KeyCode interactKey => keyCode;
      public TurnTable table;
      private bool isMoving;
      private int moveCount;

      private void Start()
      {
      }


      public string GetInteractMessage()
      {
            return "Press " + keyCode + " to interact";
      }
      public void Interact()
      {
            table.StartTurn();
      }
}
