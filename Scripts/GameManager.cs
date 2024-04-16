using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject ChessPiece;

    private bool player1Turn = true;

    [SerializeField]
    public GameObject player1Panel;
    [SerializeField]
    public GameObject player2Panel;

    [SerializeField]
    private GameObject restartPanel;

    [SerializeField]
    private Timer timer; // Reference to the Timer script

    // pos and chessPiee
    public GameObject[,] positions = new GameObject[8, 8];
    private GameObject[] playerRook = new GameObject[1];

    public bool gameOver = false;

    [SerializeField]
    private GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
        restartPanel.SetActive(false);
        winScreen.SetActive(false);
        instance = this;
        playerRook = new GameObject[]
        {
            Create("black_rook", 7, 7)
        };

        // set all piece pos on board
        for (int i = 0; i < playerRook.Length; i++)
        {
            SetPosition(playerRook[i]);
        }

        player1Panel.SetActive(true);
        player2Panel.SetActive(false);
    }

    private void Update()
    {
        CheckRookPosition();
    }

    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(ChessPiece, new Vector3(0, 0, -1), Quaternion.identity);
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
        positions[rook.GetXBoard(), rook.GetYBoard()] = obj;
    }

    public void SetPositionEmpty(int x, int y)
    {
        positions[x, y] = null;
    }

    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }

    public bool PositionOnBoard(int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) return false;
        return true;
    }

    public void CheckRookPosition()
    {
        if (GetPosition(0, 0) == playerRook[0])
        {
            timer.StopTimer();
            player1Panel.SetActive(false);
            player2Panel.SetActive(false);
            winScreen.SetActive(true);
            Debug.Log("Rook has reached position (0, 0)!");
            restartPanel.SetActive(true);

        }
    }
    public void SwitchPlayerTurn()
    {
        if (timer == null)
        {
            Debug.LogError("The timer variable is null!");
            return;
        }

        timer.ResetTimer();
        player1Turn = !player1Turn;
        player1Panel.SetActive(player1Turn);
        player2Panel.SetActive(!player1Turn);
    }

    public bool IsPlayer1Turn()
    {
        return player1Turn;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
