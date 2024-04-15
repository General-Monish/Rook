using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    [SerializeField]
    private GameObject Rook;
    // Start is called before the first frame update
    void Start()
    {   
            Instantiate(Rook, new Vector3(2.33f, 2.33f, -1.0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
