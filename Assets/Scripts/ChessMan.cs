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
            case "blackQueen": GetComponent<SpriteRenderer>().sprite = blackQueen; player = "black"; break;
            case "blackKnight": GetComponent<SpriteRenderer>().sprite = blackKnight; player = "black"; break;
            case "blackBishop": GetComponent<SpriteRenderer>().sprite = blackBishop; player = "black"; break;
            case "blackPawn": GetComponent<SpriteRenderer>().sprite = blackPawn; player = "black"; break;
            case "blackKing": GetComponent<SpriteRenderer>().sprite = blackKing; player = "black"; break;
            case "blackRook": GetComponent<SpriteRenderer>().sprite = blackRook; player = "black"; break;

            case "whiteQueen": GetComponent<SpriteRenderer>().sprite = whiteQueen; player = "white"; break;
            case "whiteKnight": GetComponent<SpriteRenderer>().sprite = whiteKnight; player = "white"; break;
            case "whiteBishop": GetComponent<SpriteRenderer>().sprite = whiteBishop; player = "white"; break;
            case "whitePawn": GetComponent<SpriteRenderer>().sprite = whitePawn; player = "white"; break;
            case "whiteKing": GetComponent<SpriteRenderer>().sprite = whiteKing; player = "white"; break;
            case "whiteRook": GetComponent<SpriteRenderer>().sprite = whiteRook; player = "white"; break;
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

    private void OnMouseUp()
    {
        DestroyMovePlates();

        InittiateMovePlates();
    }
    public void DestroyMovePlates()
    {
        var movePlates = GameObject.FindGameObjectsWithTag("MovePlate");

        foreach (var item in movePlates)
        {
            Destroy(item);
        }

    }

    public void InittiateMovePlates()
    {
        switch (name)
        {
            case "blackQueen":
            case "whiteQueen":
                LineMovePlate(1,0);
                LineMovePlate(0,1);
                LineMovePlate(1,1);
                LineMovePlate(-1,0);
                LineMovePlate(0,-1);
                LineMovePlate(-1,-1);
                LineMovePlate(-1,1);
                LineMovePlate(1,-1);
                break;
            case "blackKnight":
            case "whiteKnight":
                LMovePlate();
                break;
            case "blackBishop":
            case "whiteBishop":
                LineMovePlate(1, 1);
                LineMovePlate(1, -1);
                LineMovePlate(-1, 1);
                LineMovePlate(-1, -1);
                break;
            case "blackKing":
            case "whiteKing":
                SurroundMovePlate();
                break;
            case "blackRook":
            case "whiteRook":
                LineMovePlate(1,0);
                LineMovePlate(0,1);
                LineMovePlate(-1,0);
                LineMovePlate(0,-1);
                break;
            case "blackPawn":
                Debug.Log("Girdi");
                PawnMovePlate(xBoard, yBoard - 1);
                break;
            case "whitePawn":
                Debug.Log("Girdi");
                PawnMovePlate(xBoard, yBoard + 1);
                break;
        }
    }

    public void LineMovePlate(int xIncrement, int yIncrement)
    {
            var sc = controller.GetComponent<Game>();

            int x = xBoard + xIncrement;
            int y = yBoard + yIncrement;

            while (sc.PositionBoard(x,y) && sc.GetPosition(x,y) == null)
            {
            MovePlateSpawn(x, y);
            x += xIncrement;
            y += yIncrement;
            }
        if (sc.PositionBoard(x,y) && sc.GetPosition(x,y).GetComponent<ChessMan>().player != player)
        {
            MovePlateAttackSpawn(x, y);
        }
    }

    public void LMovePlate()
    {
        PointMovePlate(xBoard + 1, yBoard + 2);
        PointMovePlate(xBoard - 1, yBoard + 2);
        PointMovePlate(xBoard + 2, yBoard + 1);
        PointMovePlate(xBoard + 2, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 2);
        PointMovePlate(xBoard - 1, yBoard - 2);
        PointMovePlate(xBoard - 2, yBoard - 1);
        PointMovePlate(xBoard - 2, yBoard + 1);
    }

    public void SurroundMovePlate()
    {
        PointMovePlate(xBoard, yBoard + 1);
        PointMovePlate(xBoard, yBoard - 1);
        PointMovePlate(xBoard - 1 , yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard - 0);
        PointMovePlate(xBoard - 1, yBoard + 1);
        PointMovePlate(xBoard + 1, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 0);
        PointMovePlate(xBoard + 1, yBoard + 1);
    }

    public void PointMovePlate(int x, int y)
    {
        var sc = controller.GetComponent<Game>();
        if (sc.PositionBoard(x,y))
        {
            GameObject cp = sc.GetPosition(x, y);

            if (cp == null)
            {
                MovePlateSpawn(x, y);
            }
            else if (cp.GetComponent<ChessMan>().player != player)
            {
                MovePlateAttackSpawn(x, y);
            }
        }
    }


    public void PawnMovePlate(int x, int y)
    {
        var sc = controller.GetComponent<Game>();
        if (sc.PositionBoard(x, y))
        {
            if (sc.GetPosition(x,y) == null)
            {
                MovePlateSpawn(x, y);
            }

            if (sc.PositionBoard(x +1,y) && sc.GetPosition(x+1, y) != null && 
                sc.GetPosition(x+1,y).GetComponent<ChessMan>().player != player)
            {
                MovePlateAttackSpawn(x + 1, y);
            }

            if (sc.PositionBoard(x - 1, y) && sc.GetPosition(x - 1, y) != null &&
                sc.GetPosition(x - 1, y).GetComponent<ChessMan>().player != player)
            {
                MovePlateAttackSpawn(x - 1, y);
            }

        }
    }

    public void MovePlateSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        var mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        var mpScript = mp.GetComponent<MovePlate>();
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }

    public void MovePlateAttackSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        var mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        var mpScript = mp.GetComponent<MovePlate>();
        mpScript.attack = true;
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }

}
