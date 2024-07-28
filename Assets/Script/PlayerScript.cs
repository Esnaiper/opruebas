using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;


public class Walk : MonoBehaviour
{

   
    [SerializeField] private Movement movement;




    private void Update()
    {
    }



    private void FixedUpdate()
    {
              
        movement.MovePlayer();
        movement.SpeedControl();

    }





    
}
