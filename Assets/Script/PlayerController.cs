using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;

    public float speed = 20f;   //Default Speed
    

    private float xAxis;
    private float zAxis;
    
    

    
    
    
   
    

    public Transform cam;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public CharacterController controller;

    Rigidbody rb;
  

    Camera playerCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();



        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;



    }


    void Update()
    {


        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");



        Vector3 currentpositionz = new Vector3(0, 0, zAxis).normalized;
        Vector3 currentpositionx = new Vector3(xAxis, 0, 0).normalized;




        rb.AddForce(currentpositionx * speed);


        





        bool fowardpressed = Input.GetKey(KeyCode.W);
        bool backwardpressed = Input.GetKey(KeyCode.S);
        bool leftpressed = Input.GetKey(KeyCode.A);
        bool rightpressed = Input.GetKey(KeyCode.D);
        bool attack = Input.GetKeyDown(KeyCode.Mouse0);

        





        if (fowardpressed && currentpositionz.magnitude >= 0.1f)     //When pressed W  Increase speed only forward
        {

            float targetAngle = Mathf.Atan2(currentpositionz.x, currentpositionz.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);


        }

        if (backwardpressed && currentpositionz.magnitude >= 0.1f)   //When pressed S Default Speed 
        {


            float targetAngle = Mathf.Atan2(currentpositionz.x, currentpositionz.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);
        }

        if (currentpositionx.magnitude >= 0.1f)   //Speed for X
        {

            float targetAngle = Mathf.Atan2(currentpositionx.x, currentpositionx.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);
        }


    }
}
