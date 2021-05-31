using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public GameObject chessPiece;

    private GameObject[,] positions = new GameObject[8, 8];
    private GameObject[] playerBlack = new GameObject[16];
    private GameObject[] playerWhite = new GameObject[16];

    private string currentPlayer = "white";

    private bool gameOver = false;

    void Start()
    {
        playerWhite = new GameObject[]
        {
            Create("whiteRook",0,0),Create("whiteKinght",1,0),Create("whiteBishop",2,0),Create("whiteQueen",3,0),
            Create("whiteKing",4,0),Create("whiteBishop",5,0),Create("whiteKinght",6,0),Create("whiteRook",7,0),
            Create("whitePawn",0,1),Create("whitePawn",1,1),Create("whitePawn",2,1),Create("whiteQueen",3,1),
            Create("whitePawn",4,1),Create("whitePawn",5,1),Create("whitePawn",6,1),Create("whitePawn",7,1)
        };

        playerBlack = new GameObject[]
        {
            Create("blackRook",0,7),Create("blackKinght",1,7),Create("blackBishop",2,7),Create("blackQueen",3,7),
            Create("blackKing",4,7),Create("blackBishop",5,7),Create("blackKinght",6,7),Create("blackRook",7,7),
            Create("blackPawn",0,6),Create("blackPawn",1,6),Create("blackPawn",2,6),Create("blackQueen",3,6),
            Create("blackPawn",4,6),Create("blackPawn",5,6),Create("blackPawn",6,6),Create("blackPawn",7,6)
        };

        for(var i = 0; i< playerBlack.Length; i++)
        {
            SetPosition(playerBlack[i]);
            SetPosition(playerWhite[i]);
        }
    }


    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(chessPiece, new Vector3(0, 0, -1), Quaternion.identity);
        ChessMan cm = obj.GetComponent<ChessMan>();
        cm.name = name;
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate();
        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        ChessMan cm = obj.GetComponent<ChessMan>();
        positions[cm.GetXBoard(),cm.GetYBoard()] = obj;
    }
}