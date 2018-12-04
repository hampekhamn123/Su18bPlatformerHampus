using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public int isGrounded;

    public int jumpValue = 0;

    //händer när objektet som scriptet ligger på kolliderar med en annan trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {   //om hitboxen som scriptet ligger på är när något ska isGrounded bli true och jumpValue ska bli 0
        isGrounded++;
        jumpValue = 0;
    }

    //händer när objektet som scriptet ligger på kolliderar med en annan trigger
    private void OnTriggerExit2D(Collider2D collision)
    {   //om hitboxen som scriptet ligger på inte är när något ska isGrounded bli false
        isGrounded--;
    }
}
