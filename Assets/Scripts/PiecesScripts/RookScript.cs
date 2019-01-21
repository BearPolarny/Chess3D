using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookScript : ChessPiece {

    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[8,8];
        ChessPiece c;
        int i;
        // Right

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
