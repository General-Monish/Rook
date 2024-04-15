using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;
    [SerializeField]
    private GameObject movePlate;

    // Positions on Board
    private int xBoard = -1;
    private int yBoard = -1;

    // Var To Keep track Of Players
    private string player1;
    private string player2;

    // player chess Piece Referance
    [SerializeField]
    private Sprite black_rook;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");

        SetCordinates();

        switch (this.name)
        {
            case "balck_rook": this.GetComponent<SpriteRenderer>().sprite=black_rook; break;
        }
    }

    public void SetCordinates()
    {
        float x = xBoard;
        float y = yBoard;

        x *= .66f;
        y *= .66f;

        x += -2.3f;
        y += -2.3f;

        this.transform.position=new Vector3(x, y, -1.0f);
    }

    public int GetXBoard()
    {
        return xBoard;
    }

    public int GetYBoard()
    {
        return yBoard;
    }

    public void SetXBoard(int x)
    {
        xBoard = x;
    }

    public void SetYBoard(int y)
    {
        yBoard = y;
    }

  
}
