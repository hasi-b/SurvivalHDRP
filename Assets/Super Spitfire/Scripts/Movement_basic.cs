using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_basic : MonoBehaviour
{


    public float speed;
    public float power;
    public GameObject airPlane;
     Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        bool isSpace = Input.GetKey(KeyCode.Space);
        bool isShift = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool isRight = Input.GetKey(KeyCode.RightArrow);
        bool isLeft = Input.GetKey(KeyCode.LeftArrow);
        bool isForward = Input.GetKey(KeyCode.UpArrow);
        bool isbackward = Input.GetKey(KeyCode.DownArrow);
        bool isA = Input.GetKey(KeyCode.A);
        bool isD = Input.GetKey(KeyCode.D);

        Vector3 rotZ = new Vector3(0.0f,0.0f,-0.1f);
        Vector3 rotX = new Vector3(0.1f,0f,0f);
        Vector3 rotY = new Vector3(0f,0.2f,0f);


        if (isSpace)
        {
            airPlane.transform.Rotate(rotZ);
        }
        else if(isShift)
        {
            airPlane.transform.Rotate(-rotZ);
        }

        if(isRight == true && airPlane.transform.rotation.x <= 90)
        {
            airPlane.transform.Rotate(rotX);
            airPlane.transform.Rotate(rotY);
        }
        else if(isLeft == true && airPlane.transform.rotation.x>=-90)
        {
            airPlane.transform.Rotate(-rotX);
            airPlane.transform.Rotate(-rotY);
        }
        else if(isForward)
        {
            rb.AddRelativeForce(Vector3.forward * power * 100);
            
        }
        else if (isbackward)
        {
            rb.AddRelativeForce(Vector3.forward * power * -100);

        }

        else if (isA)
        {
            rb.AddRelativeForce(Vector3.right * power * -100);
            airPlane.transform.Rotate(-rotX);
        }
        else if (isD)
        {
            rb.AddRelativeForce(Vector3.left * power * -100);
            airPlane.transform.Rotate(rotX);
        }


    }
}
