using UnityEngine;

class CameraScript : MonoBehaviour
{
    public GameObject target;
    Vector3 speed = Vector3.zero;

    private void Update()
    {
        if (target != null)
        {
            if (transform.position.y >= 1)
            {
                transform.LookAt(target.transform);
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.RotateAround(target.transform.position, Vector3.down, Time.deltaTime * 30);
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * 30);
                }
                if (transform.rotation.y > 180)
                {
                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        transform.RotateAround(target.transform.position, Vector3.left, Time.deltaTime * 30);
                    }
                    if (Input.GetKey(KeyCode.DownArrow))
                    {
                        transform.RotateAround(target.transform.position, Vector3.right, Time.deltaTime * 30);
                    }
                }
                else
                {

                    if (Input.GetKey(KeyCode.DownArrow))
                    {
                        transform.RotateAround(target.transform.position, Vector3.left, Time.deltaTime * 30);
                    }
                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        transform.RotateAround(target.transform.position, Vector3.right, Time.deltaTime * 30);
                    }
                }


            }
            else transform.position = new Vector3(transform.position.x, 1, transform.position.z);

            if (Input.GetKey(KeyCode.W))
            {
                //Debug.Log("Scroll");
                Vector3 pre = Camera.main.transform.position;
                Vector3 targ = (Vector3.zero - pre).normalized;
                Camera.main.transform.position += targ;
            }
            if (Input.GetKey(KeyCode.S))
            {
                Vector3 pre = Camera.main.transform.position;
                Vector3 targ = (Vector3.zero - pre).normalized;
                Camera.main.transform.position -= targ;
            }
        }
    }
}