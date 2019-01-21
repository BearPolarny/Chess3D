using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardHighlightScript : MonoBehaviour
{

    public static BoardHighlightScript Instance;
    public GameObject highlightPrefab;
    private List<GameObject> highlights;
    public GameObject pieceHighLight;
    

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            highlights = new List<GameObject>();
            pieceHighLight.SetActive(true);
        }
    }

    private GameObject GetHiglightObject()
    {
        GameObject go = highlights.Find(g => !g.activeSelf);
        if (go == null)
        {
            go = Instantiate(highlightPrefab);
            highlights.Add(go);
        }

        return go;
    }

    public void HighlightAllowedMoves(bool[,] moves)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (moves[i, j])
                {
                    GameObject go = GetHiglightObject();
                    go.SetActive(true);
                    go.transform.position = new Vector3(2 * i + 1, 1.5f, 2 * j + 1);

                }
            }
        }
    }

    public void ShowPieceHighlight(int x, int z)
    {
        if (pieceHighLight.activeSelf)
        {
            pieceHighLight = Instantiate(pieceHighLight);
        }
        pieceHighLight.SetActive(true);
        pieceHighLight.transform.position = new Vector3(2 * x + 1, 1.5f, 2 * z + 1);
    }

    public void HideHiglights()
    {
        foreach (GameObject g in highlights)
        {
            g.SetActive(false);
        }
        pieceHighLight.SetActive(false);
    }
}
