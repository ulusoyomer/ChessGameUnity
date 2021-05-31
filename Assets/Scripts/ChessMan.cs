using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessMan : MonoBehaviour
{
    public GameObject controller;
    public GameObject movePlate;

    private int xBoard = -1;
    private int yBoard = -1;

    private string player;

    public Sprite blackQueen, blackKnight, blackBishop, blackKing, blackRook, blackPawn;
    public Sprite whiteQueen, whiteKnight, whiteBishop, whiteKing, whiteRook, whitePawn;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        SetCoords();

        switch (name)
        {
            case "blackQueen": this.GetComponent<SpriteRenderer>().sprite = blackQueen; break;
            case "blackKnight": this.GetComponent<SpriteRenderer>().sprite = blackKnight; break;
            case "blackBishop": this.GetComponent<SpriteRenderer>().sprite = blackBishop; break;
            case "blackPawn": this.GetComponent<SpriteRenderer>().sprite = blackPawn; break;
            case "blackKing": this.GetComponent<SpriteRenderer>().sprite = blackKing; break;
            case "blackRook": this.GetComponent<SpriteRenderer>().sprite = blackRook; break;

            case "whiteQueen": this.GetComponent<SpriteRenderer>().sprite = whiteQueen; break;
            case "whiteKnight": this.GetComponent<SpriteRenderer>().sprite = whiteKnight; break;
            case "whiteBishop": this.GetComponent<SpriteRenderer>().sprite = whiteBishop; break;
            case "whitePawn": this.GetComponent<SpriteRenderer>().sprite = whitePawn; break;
            case "whiteKing": this.GetComponent<SpriteRenderer>().sprite = whiteKing; break;
            case "whiteRook": this.GetComponent<SpriteRenderer>().sprite = whiteRook; break;
        }
    }

    public void SetCoords()
    {
        float x = xBoard;
        float y = yBoard;

        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        transform.position = new Vector3(x, y, -1.0f);
    }

    public int GetXBoard()
    {
        return xBoard;
    }

    public int GetYBoard()
    {
        return yBoard;
    }

    public void SetXBoard(int xBoard)
    {
        this.xBoard = xBoard;
    }

    public void SetYBoard(int yBoard)
    {
        this.yBoard = yBoard;
    }
}
