using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5f;
    float xAxis;
    float zAxis;

    Vector3 Current = new Vector3(0, 0, 0);
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {


        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");

        Current.x = xAxis;
        Current.z = zAxis;

        rb.AddForce(Current * speed);
        
    }
}
