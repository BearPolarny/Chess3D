using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;

    private bool[,] allowedMoves { get; set; }

    //private Vector3 speed = new Vector3(0.2f, 0f, .2f);

    private const float TILE_SIZE = 2f;
    private const float TILE_OFFSET = 1f;

    private int selectionX = -1;
    private int selectionZ = -1;

    public List<GameObject> ChessPiecesPrefabs;
    private List<GameObject> activeChessPieces;

    private Quaternion orientation = Quaternion.Euler(0, 0, 0);

    public ChessPiece[,] ChessPieces { set; get; }
    public ChessPiece selectedChessPiece;

    public bool IsWhiteTurn = true;

    public int[] EnPassant { get; set; }
    

    // Use this for initialization
    void Start()
    {
        if (Instance == null)
        {
            SpawnAllPieces();
            Instance = this;

        }
    }
    // Update is called once per frame
    void Update()
    {
        UpdateSelection();

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Klik!");
            if (selectionX >= 0 && selectionZ >= 0)
            {
                //Debug.Log("Pionek!");
                if (selectedChessPiece == null)
                {
                    // Select the chessPiece
                    SelectChessPiece(selectionX, selectionZ);
                }
                else
                {
                    // Move Chesspiece
                    MoveChessPiece(selectionX, selectionZ);
                }
            }
        }
        //DrawChessboard();
    }


    private void EndGame()
    {
        if (IsWhiteTurn)
        {
            Debug.Log("White Team Wins");
        }
        else Debug.Log("Black Team Wins");

        foreach (GameObject gameObject in activeChessPieces)
        {
            Destroy(gameObject);
        }
        IsWhiteTurn = true;
        BoardHighlightScript.Instance.HideHiglights();
        SpawnAllPieces();
    }

    /*
    void DrawChessboard()
    {
        Vector3 widthLine = Vector3.right * 8;
        Vector3 heightLine = Vector3.forward * 8;

        for (int i = 0; i < 9; i++)
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine(start, start + widthLine);
            for (int j = 0; j < 9; j++)
            {
                start = Vector3.right * j;
                Debug.DrawLine(start, start + heightLine);
            }
        }

        // Draw selection

        if (selectionX >= 0 &&
            selectionY >= 0)
        {
            Debug.DrawLine(
                Vector3.forward * selectionY + Vector3.right * selectionX,
                Vector3.forward * (selectionY + 1) + Vector3.right * (selectionX + 1));
            Debug.DrawLine(
                Vector3.forward * (selectionY + 1) + Vector3.right * selectionX,
                Vector3.forward * selectionY + Vector3.right * (selectionX + 1));
        }

    //}
    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="z"></param>
    /// <returns>Vector3 with center of tile x, y</returns>
    public static Vector3 GetTileCenter(int x, int z)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (TILE_SIZE * x) + TILE_OFFSET;
        origin.z += (TILE_SIZE * z) + TILE_OFFSET;
        origin.y += 1.2f;
        return origin;
    }


    private void MoveChessPiece(int x, int z)
    {
        if (allowedMoves[x, z])
        {
            ChessPiece c = ChessPieces[x, z];
            if (c != null && c.isWhite != IsWhiteTurn)
            {

                // Captured
                // If king end
                if (c.GetType() == typeof(KingScript))
                {
                    //END
                    Debug.Log("WIN");
                    EndGame();
                    return;
                }

                //activeChessPieces.Remove(c.gameObject);
                //Destroy(c.gameObject);
                c.FlyYouFool();
                c.GetComponent<Rigidbody>().useGravity = false;
            }


            if (x == EnPassant[0] && z == EnPassant[1])
            {
                if (IsWhiteTurn)
                {
                    c = ChessPieces[x, z - 1];
                }
                else
                {
                    c = ChessPieces[x, z + 1];
                }
                //activeChessPieces.Remove(c.gameObject);
                //Destroy(c.gameObject);
                c.FlyYouFool();
                c.GetComponent<Rigidbody>().useGravity = false;

            }

            EnPassant[0] = -1;
            EnPassant[1] = -1;
            if (selectedChessPiece.GetType() == typeof(PawnScript))
            {
                if (z == 7)
                {
                    activeChessPieces.Remove(selectedChessPiece.gameObject);
                    Destroy(selectedChessPiece.gameObject);
                    SpawnChessPiece(1, x, z);
                    selectedChessPiece = ChessPieces[x, z];
                }
                else
                if (z == 0)
                {
                    activeChessPieces.Remove(selectedChessPiece.gameObject);
                    Destroy(selectedChessPiece.gameObject);
                    SpawnChessPiece(7, x, z);
                    selectedChessPiece = ChessPieces[x, z];
                }

                if (selectedChessPiece.CurrentZ == 1 && z == 3)
                {
                    EnPassant[0] = x;
                    EnPassant[1] = z - 1;
                }
                else
                if (selectedChessPiece.CurrentZ == 6 && z == 4)
                {
                    EnPassant[0] = x;
                    EnPassant[1] = z + 1;
                }
            }

            ChessPieces[selectedChessPiece.CurrentX, selectedChessPiece.CurrentZ] = null;
            //selectedChessPiece.transform.position = GetTileCenter(x, z);
            selectedChessPiece.SetPosition(x, z);
            ChessPieces[x, z] = selectedChessPiece;
            IsWhiteTurn = !IsWhiteTurn;
        }
        else
        {

            Debug.Log("Invalid");
        }
        BoardHighlightScript.Instance.HideHiglights();
        selectedChessPiece = null;

    }

    private void SelectChessPiece(int x, int z)
    {
        if (ChessPieces[x, z] == null)
        {
            return;
        }

        if (ChessPieces[x, z].isWhite != IsWhiteTurn)
        {
            return;
        }

        bool hasMinOneMove = false;

        allowedMoves = ChessPieces[x, z].PossibleMove();

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (allowedMoves[i, j])
                {
                    hasMinOneMove = true;
                }
            }
        }

        if (!hasMinOneMove)
        {
            return;
        }

        selectedChessPiece = ChessPieces[x, z];
        BoardHighlightScript.Instance.HighlightAllowedMoves(allowedMoves);
        BoardHighlightScript.Instance.ShowPieceHighlight(x, z);
    }

    /// <summary>
    /// Spawns all chess pieces
    /// </summary>
    private void SpawnAllPieces()
    {
        EnPassant = new int[2] { -1, -1 };


        activeChessPieces = new List<GameObject>();
        ChessPieces = new ChessPiece[8, 8];

        // Whites:
        SpawnChessPiece(0, 4, 0); // WH_KING
        SpawnChessPiece(1, 3, 0); // WH_QUEEN
        SpawnChessPiece(2, 2, 0); // WH_BISHOP_1
        SpawnChessPiece(2, 5, 0); // WH_BISHOP_2
        SpawnChessPiece(3, 1, 0); // WH_KNIGHT_1
        SpawnChessPiece(3, 6, 0); // WH_KNIGHT_2
        SpawnChessPiece(4, 0, 0); // WH_ROOK_1
        SpawnChessPiece(4, 7, 0); // WH_ROOK_2
        // Pawns:
        for (int i = 0; i < 8; i++)
        {
            SpawnChessPiece(5, i, 1);
        }

        orientation = Quaternion.Euler(0, 180, 0);

        // Whites:
        SpawnChessPiece(6, 4, 7); // BL_KING
        SpawnChessPiece(7, 3, 7); // BL_QUEEN
        SpawnChessPiece(8, 2, 7); // BL_BISHOP_1
        SpawnChessPiece(8, 5, 7); // BL_BISHOP_2
        SpawnChessPiece(9, 1, 7); // BL_KNIGHT_1
        SpawnChessPiece(9, 6, 7); // BL_KNIGHT_2
        SpawnChessPiece(10, 0, 7); // BL_ROOK_1
        SpawnChessPiece(10, 7, 7); // BL_ROOK_2
        // Pawns:
        for (int i = 0; i < 8; i++)
        {
            SpawnChessPiece(11, i, 6);
        }
    }

    /// <summary>
    /// Spawns given chess piece at given coordinates
    /// </summary>
    /// <param name="index">Chess Piece index</param>
    /// <param name="x"> Tile x</param>
    /// <param name="z"> Tile z</param>
    private void SpawnChessPiece(int index, int x, int z)
    {
        GameObject go = Instantiate(ChessPiecesPrefabs[index], GetTileCenter(x, z), orientation) as GameObject;
        go.transform.SetParent(transform);
        ChessPieces[x, z] = go.GetComponent<ChessPiece>();
        ChessPieces[x, z].SetPosition(x, z);
        activeChessPieces.Add(go);

    }

    /// <summary>
    /// Updates Gamebject selectedy by mouse
    /// </summary>
    void UpdateSelection()
    {

        RaycastHit hit;
        if (selectedChessPiece == null)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f, LayerMask.GetMask("Piece")))
            {

                selectionX = (int)hit.point.x / 2;
                selectionZ = (int)hit.point.z / 2;
                //Debug.Log("Piece");
            }
        }
        else
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f, LayerMask.GetMask("Chessplane")))
            {

                selectionX = (int)hit.point.x / 2;
                selectionZ = (int)hit.point.z / 2;
                //Debug.Log("Podłoga");
            }
            else
            {
                selectionX = -1;
                selectionZ = -1;
            }
        }
        //Debug.Log(selectionZ);
    }
}
