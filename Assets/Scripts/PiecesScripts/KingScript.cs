using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingScript : ChessPiece
{
    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[8, 8];
        int i, j;
        ChessPiece c;

        //Top
        i = CurrentX - 1;
        j = CurrentZ + 1;
        if (CurrentZ != 7)
        {
            for (int k = 0; k < 3; k++)
            {
                if (i >= 0 || i < 8)
                {
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
                    }

                }
                i++;
            }
        }
        // Down
        i = CurrentX - 1;
        j = CurrentZ - 1;
        if (CurrentZ != 0)
        {
            for (int k = 0; k < 3; k++)
            {
                if (i >= 0 || i < 8)
                {
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
                    }

                }
                i++;
            }
        }
        //middle left
        if (CurrentX != 0)
        {
            i = CurrentX - 1;
            j = CurrentZ;
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
            }
        }
        // middle right
        if (CurrentX != 7)
        {
            i = CurrentX + 1;
            j = CurrentZ;
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
            }
        }
        return r;
    }
}
