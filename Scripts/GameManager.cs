using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject ChessPiece;


    // pos and chessPiee
    public GameObject[,] positions = new GameObject[8, 8];
    private GameObject[] playerRook=new GameObject[1];

    private bool gameOver = false;

    [SerializeField]
    private GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
        winScreen.SetActive(false);
        instance = this;
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
    private void Update()
    {
        CheckRookPosition();
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
   
    public void SetPositionEmpty(int x,int y)
    {
         positions[x,y] = null;
    }

    public GameObject GetPosition(int x,int y)
    {
        return positions[x,y];
    }

    public bool PositionOnBoard(int x,int y)
    {
        if(x<0 || y<0 || x>=positions.GetLength(0) || y>=positions.GetLength(1)) return false;
        return true;
    }

    public void CheckRookPosition()
    {
        if (GetPosition(0, 0) == playerRook[0])
        {
            winScreen.SetActive(true);
            Debug.Log("Rook has reached position (0, 0)!");
        }
    }
}
