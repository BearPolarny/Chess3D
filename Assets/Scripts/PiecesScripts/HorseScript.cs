using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseScript : ChessPiece
{
    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[8, 8];

        // Up-Left
        KnightMove(CurrentX - 1, CurrentZ + 2, ref r);
        // Up-Right
        KnightMove(CurrentX + 1, CurrentZ + 2, ref r);
        // Right-Up
        KnightMove(CurrentX + 2, CurrentZ + 1, ref r);
        // Right-Down
        KnightMove(CurrentX + 2, CurrentZ - 1, ref r);
        // Down-Right
        KnightMove(CurrentX + 1, CurrentZ - 2, ref r);
        // Down-Left
        KnightMove(CurrentX - 1, CurrentZ - 2, ref r);
        // Left-Up
        KnightMove(CurrentX - 2, CurrentZ + 1, ref r);
        // Left-Down
        KnightMove(CurrentX - 2, CurrentZ - 1, ref r);

        return r;
    }

    public void KnightMove(int x, int z, ref bool[,] r)
    {
        ChessPiece c;
        if (x >= 0 && x < 8 && z >= 0 && z < 8)
        {
            c = BoardManager.Instance.ChessPieces[x, z];
            if (c == null)
            {
                r[x, z] = true;
            }
            else if (isWhite != c.isWhite)
            {
                r[x, z] = true;
            }
        }
    }
}
