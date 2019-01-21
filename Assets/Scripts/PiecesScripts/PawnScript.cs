using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnScript : ChessPiece
{

    override
    public bool[,] PossibleMove()
    {
        bool[,] r = new bool[8, 8];
        ChessPiece c, c2;

        int[] e = BoardManager.Instance.EnPassant;

        if (isWhite)
        {
            // Diagonal LEft
            if (CurrentX != 0 && CurrentZ != 7)
            {
                
                if (e[0] == CurrentX - 1 && e[1] == CurrentZ + 1)
                {
                    r[e[0], e[1]] = true;
                }
                c = BoardManager.Instance.ChessPieces[CurrentX - 1, CurrentZ + 1];
                if (c != null && !c.isWhite)
                {
                    r[CurrentX - 1, CurrentZ + 1] = true;

                }
            }

            // Diagonal Right   
            if (CurrentX != 7 && CurrentX != 7)
            {

                if (e[0] == CurrentX + 1 && e[1] == CurrentZ + 1)
                {
                    r[e[0], e[1]] = true;
                }
                c = BoardManager.Instance.ChessPieces[CurrentX + 1, CurrentZ + 1];
                if (c != null && !c.isWhite)
                {
                    r[CurrentX + 1, CurrentZ + 1] = true;

                }
            }
            // Middle
            if (CurrentZ != 7)
            {
                c = BoardManager.Instance.ChessPieces[CurrentX, CurrentZ + 1];
                if (c == null)
                {
                    r[CurrentX, CurrentZ + 1] = true;

                }
            }

            // Double Middle
            if (CurrentZ == 1)
            {
                c = BoardManager.Instance.ChessPieces[CurrentX, CurrentZ + 1];
                c2 = BoardManager.Instance.ChessPieces[CurrentX, CurrentZ + 2];
                if (c == null && c2 == null)
                {
                    r[CurrentX, CurrentZ + 2] = true;
                }
            }
        }
        else
        {
            // Diagonal LEft
            if (CurrentX != 0 && CurrentZ != 0)
            {
                if (e[0] == CurrentX - 1 && e[1] == CurrentZ - 1)
                {
                    r[e[0], e[1]] = true;
                }
                c = BoardManager.Instance.ChessPieces[CurrentX - 1, CurrentZ - 1];
                if (c != null && c.isWhite)
                {
                    r[CurrentX - 1, CurrentZ - 1] = true;

                }
            }

            // Diagonal Right   
            if (CurrentX != 7 && CurrentX != 0)
            {
                if (e[0] == CurrentX + 1 && e[1] == CurrentZ - 1)
                {
                    r[e[0], e[1]] = true;
                }
                c = BoardManager.Instance.ChessPieces[CurrentX + 1, CurrentZ - 1];
                if (c != null && c.isWhite)
                {
                    r[CurrentX + 1, CurrentZ - 1] = true;

                }
            }
            // Middle
            if (CurrentZ != 0)
            {
                c = BoardManager.Instance.ChessPieces[CurrentX, CurrentZ - 1];
                if (c == null)
                {
                    r[CurrentX, CurrentZ - 1] = true;

                }
            }

            // Double Middle
            if (CurrentZ == 6)
            {
                c = BoardManager.Instance.ChessPieces[CurrentX, CurrentZ - 1];
                c2 = BoardManager.Instance.ChessPieces[CurrentX, CurrentZ - 2];
                if (c == null && c2 == null)
                {
                    r[CurrentX, CurrentZ - 2] = true;
                }
            }
        }
        return r;
    }
}
