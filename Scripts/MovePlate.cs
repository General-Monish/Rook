using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject gameManager;

    GameObject referance = null;

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
