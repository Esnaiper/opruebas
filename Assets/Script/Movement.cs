using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEditorInternal;



public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float aceleration = 5000;
    [SerializeField] private float groundDrag = 5;
    [SerializeField] private float airDrag = 2;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask whatIsGround;


    bool grounded;
    [Header("GameInput")]
    [SerializeField] private GameInput gameinput;



    private Vector3 lastPos;
    Vector3 Velocidad;



    Rigidbody rb;
    private float moveDir;

    private void Start()
    {

        //RIgitbody
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;


        lastPos = transform.position;
    }

    private void Update()
    {
        //GroundCheck
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, whatIsGround);

        if (grounded)
        {
            rb.linearDamping = groundDrag;
            //Debug.Log("Isgrounded");
        }
        else
        {
            rb.linearDamping = airDrag; ;

            //Debug.Log("IsNOTgrounded");
        }

        //velocidad calculator

        //if (lastPos != transform.position)
        //{
        //    Debug.Log(Velocidad = (transform.position - lastPos) / Time.deltaTime);


        //    lastPos = transform.position;
        //}



    }


    public void MovePlayer()
    {
     

        // Movement AD
        Vector2 inputVector = gameinput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0.0f, 0.0f);
       
       
        rb.AddForce(moveDir*aceleration, ForceMode.Force);

   
    }

   
    public void SpeedControl()
    {

        


        Vector3 flatVel = new Vector3(Mathf.Abs(rb.linearVelocity.x), 0.0f, 0.0f);
        

        if (flatVel.magnitude > moveSpeed)
        {


            Vector3 moveSpeedVector = new Vector3 (moveSpeed, 0, 0);

            Debug.Log("MoveSpeed" + moveSpeedVector);


            Vector3 brakeSpeed = (flatVel) - moveSpeedVector;

            Vector2 inputVector = gameinput.GetMovementVectorNormalized();
            Vector3 moveDir = new Vector3(inputVector.x, 0.0f, 0.0f);

            Vector3 breakeSpeedLimit =Vector3.Scale(-brakeSpeed, moveDir);

            rb.AddRelativeForce(breakeSpeedLimit, ForceMode.Impulse);

            Debug.Log("MoveSpeed" + moveSpeedVector + "breakSpeed" + breakeSpeedLimit + "flatVel" + flatVel);
            Debug.Log("LIMITANDO");
           
       
        }
    }
   
}
