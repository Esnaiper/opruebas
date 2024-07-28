using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;



public class GameInput : MonoBehaviour
{



    private InputPlayerActions inputPlayerActions;

    private void Awake()
    {
        inputPlayerActions = new InputPlayerActions();
        inputPlayerActions.Player.Enable();

    }

    public Vector2 GetMovementVectorNormalized() { 

   
         Vector2 inputVector = inputPlayerActions.Player.Move.ReadValue<Vector2>();
          


        inputVector = inputVector.normalized;

        return inputVector;

    }


}
