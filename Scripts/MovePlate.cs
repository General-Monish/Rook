using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject gameManager;

    GameObject referance = null;

    private int clickCount = 1;

    // Board Positions 
    int matrixX;
    int matrixY;

    public void OnMouseUp()
    {

        gameManager = GameObject.FindGameObjectWithTag("GameController");

        gameManager.GetComponent<GameManager>().SetPositionEmpty(referance.GetComponent<Rook>().GetXBoard(),
        referance.GetComponent<Rook>().GetYBoard());

        referance.GetComponent<Rook>().SetXBoard(matrixX);
        referance.GetComponent<Rook>().SetYBoard(matrixY);
        referance.GetComponent<Rook>().SetCordinates();

        gameManager.GetComponent<GameManager>().SetPosition(referance);

        referance.GetComponent<Rook>().DestroyMovePlates();

        clickCount++;

        // On the second click
        if (clickCount == 2)
        {
            // Switch players
            if (GameManager.instance != null)
            {
                GameManager.instance.SwitchPlayerTurn();
            }

            // Reset click count
            clickCount = 1;
        }
    }



    private void OnMouseDown()
    {
       
    }
    public void SetCor(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public void SetReferance(GameObject obj)
    {
        referance = obj;
    }

    public GameObject GetReferance()
    {
        return referance;
    }
}
