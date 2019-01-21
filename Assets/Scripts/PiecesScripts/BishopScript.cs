using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopScript : ChessPiece
{

    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[8, 8];

        ChessPiece c;
        int i, j;

        // Top-Left
        i = CurrentX;
        j = CurrentZ;
        while (true)
        {
            i--;
            j++;
            if (i < 0 || j > 7)
            {
                break;
            }
            c = BoardManager.Instance.ChessPieces[i, j];
            if (c == null)
            {
                r[i, j] = true;
            }
            else
            {
                if (isWhite != c.isWhite)

                {
                    r[i, j] = true;
                }
                break;
            }
        }
        // Top-Right
        i = CurrentX;
        j = CurrentZ;
        while (true)
        {
            i++;
            j++;
            if (i > 7 || j > 7)
            {
                break;
            }
            c = BoardManager.Instance.ChessPieces[i, j];
            if (c == null)
            {
                r[i, j] = true;
            }
            else
            {
                if (isWhite != c.isWhite)

                {
                    r[i, j] = true;
                }
                break;
            }
        }
        // Down-Left
        i = CurrentX;
        j = CurrentZ;
        while (true)
        {
            i--;
            j--;
            if (i < 0 || j < 0)
            {
                break;
            }
            c = BoardManager.Instance.ChessPieces[i, j];
            if (c == null)
            {
                r[i, j] = true;
            }
            else
            {
                if (isWhite != c.isWhite)

                {
                    r[i, j] = true;
                }
                break;
            }
        }
        // Down-Right
        i = CurrentX;
        j = CurrentZ;
        while (true)
        {
            i--;
            j++;
            if (i < 0 || j > 7)
            {
                break;
            }
            c = BoardManager.Instance.ChessPieces[i, j];
            if (c == null)
            {
                r[i, j] = true;
            }
            else
            {
                if (isWhite != c.isWhite)

                {
                    r[i, j] = true;
                }
                break;
            }
        }

        return r;
    }
}
