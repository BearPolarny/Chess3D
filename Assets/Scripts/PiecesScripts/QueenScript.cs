using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenScript : ChessPiece
{
    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[8, 8];
        int i, j;
        ChessPiece c;
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


        i = CurrentX;
        while (true)
        {
            i++;
            if (i >= 8)
            {
                break;
            }
            c = BoardManager.Instance.ChessPieces[i, CurrentZ];
            if (c == null)
            {
                r[i, CurrentZ] = true;
            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, CurrentZ] = true;
                }
                break;
            }
        }
        // Left
        i = CurrentX;
        while (true)
        {
            i--;
            if (i < 0)
            {
                break;
            }
            c = BoardManager.Instance.ChessPieces[i, CurrentZ];
            if (c == null)
            {
                r[i, CurrentZ] = true;
            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, CurrentZ] = true;
                }
                break;
            }
        }
        // UP
        i = CurrentZ;
        while (true)
        {
            i++;
            if (i >= 8)
            {
                break;
            }
            c = BoardManager.Instance.ChessPieces[CurrentX, i];
            if (c == null)
            {
                r[CurrentX, i] = true;
            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[CurrentX, i] = true;
                }
                break;
            }
        }
        // Down
        i = CurrentZ;
        while (true)
        {
            i--;
            if (i < 0)
            {
                break;
            }
            c = BoardManager.Instance.ChessPieces[CurrentX, i];
            if (c == null)
            {
                r[CurrentX, i] = true;
            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[CurrentX, i] = true;
                }
                break;
            }
        }

        return r;
    }
}
