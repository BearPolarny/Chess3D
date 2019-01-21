using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPiece : MonoBehaviour
{

    public int CurrentX { get; set; }
    public int CurrentZ { get; set; }

    public bool Blow { get; set; }

    public bool isWhite;
    Vector3 targetPosition;
    Vector3 velocity = Vector3.zero;
    float time = 1f;
    public float dist = 0.1f;


    private void Start()
    {
        targetPosition = this.transform.position;
    }

    public void SetPosition(int x, int z)
    {
        CurrentX = x;
        CurrentZ = z;
        targetPosition = BoardManager.GetTileCenter(x, z);
        velocity = Vector3.zero;
    }

    public virtual bool[,] PossibleMove()
    {
        return new bool[8, 8];
    }

    public void FlyYouFool()
    {
        targetPosition.y = 20;
        velocity = Vector3.zero;
    }

    private void Update()
    {

        if (transform.position.x != targetPosition.x || transform.position.z != targetPosition.z)
        {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, targetPosition, ref velocity, time);
        }
        if (transform.position.y != targetPosition.y)
        {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, targetPosition, ref velocity, time);
        }
    }


}
