using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ChessPiece;


    // pos and chessPiee
    private GameObject[,] positions = new GameObject[8, 8];
    private GameObject[] playerRook=new GameObject[1];

    private string currentPlayer = "Player1";

    private bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRook = new GameObject[]
        {
            Create("black_rook",7,7)
        };

        // set all piece pos on board
        for(int i = 0;i<playerRook.Length;i++)
        {
            SetPosition(playerRook[i]);
        }
    }

    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(ChessPiece,new Vector3(0,0,-1),Quaternion.identity);
        Rook rook = obj.GetComponent<Rook>();
        rook.name = name;
        rook.SetXBoard(x);
        rook.SetYBoard(y);
        rook.Activate();
        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        Rook rook = obj.GetComponent<Rook>();
        positions[rook.GetXBoard(), rook.GetYBoard()]=obj;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
