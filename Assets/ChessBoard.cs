using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
      public List<ChessSquare> chessSquareList = new List<ChessSquare>();
      public List<GameObject> chessPieceList = new List<GameObject>();
      [SerializeField] private GameObject chessPiecePrefab;
      private void Start()
      {
            GetAllSquares();
            PlacePiece(chessPiecePrefab, chessSquareList[10].transform);
            List<Transform> squarePath = new List<Transform>();
            squarePath.Add(chessSquareList[10].transform);
            squarePath.Add(chessSquareList[11].transform);
            squarePath.Add(chessSquareList[12].transform);
            squarePath.Add(chessSquareList[20].transform);
            StartCoroutine(MovePieceCoroutine(chessSquareList[10].transform.GetChild(0).gameObject, squarePath));
      }
      private void GetAllSquares()
      {
            for (int i = 0; i < 8; i++)
            {
                  for (int j = 0; j < 8; j++)
                  {
                        chessSquareList.Add(transform.GetChild(i).transform.GetChild(j).GetComponent<ChessSquare>());
                  }
            }
      }
      private void PlacePiece(GameObject chessPiece, Transform chessSquareTransform)
      {
            var piece = Instantiate(chessPiece, chessSquareTransform.position, Quaternion.identity, chessSquareTransform);
            chessPieceList.Add(piece);
      }


      bool hasSetParent = false;


      IEnumerator MovePieceCoroutine(GameObject chessPiece, List<Transform> chessSquareTransformList)
      {
            int listCount = 0;
            bool hasFinishedMoving = false;

            while (listCount < chessSquareTransformList.Count - 1)
            {
                  Transform targetSquare = chessSquareTransformList[listCount + 1];

                  while (Vector3.Distance(chessPiece.transform.position, targetSquare.position) > 0.01f)
                  {
                        float step = 0.1f * Time.deltaTime * 10;
                        chessPiece.transform.position = Vector3.MoveTowards(chessPiece.transform.position, targetSquare.position, step);
                        yield return null;
                  }

                  listCount++;

                  if (listCount < chessSquareTransformList.Count)
                  {
                        // Snap the piece to the final position
                        chessPiece.transform.position = targetSquare.position;

                        // Set the parent after the piece has reached the final position
                        chessPiece.transform.SetParent(targetSquare);
                  }

                  // If no movement has occurred for a certain number of frames, consider the movement as complete
                  if (listCount > 10)  // Adjust this value based on your needs
                  {
                        hasFinishedMoving = true;
                        break;
                  }
            }

            // Wait for one more frame to ensure the piece has fully settled
            yield return null;

            // Check if the piece has finished moving
            if (hasFinishedMoving && !hasSetParent && listCount < chessSquareTransformList.Count - 1)
            {
                  Debug.Log("SetParent");
                  // Set the parent after the piece has reached the final position
                  chessPiece.transform.SetParent(chessSquareTransformList[listCount]);
                  hasSetParent = true;
            }
      }


}
