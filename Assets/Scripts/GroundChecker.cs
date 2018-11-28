using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool isGrounded;

    public int jumpValue = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {   //om hitboxen som scriptet ligger på är när något ska isGrounded bli true och jumpValue ska bli 0
        isGrounded = true;
        jumpValue = 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {   //om hitboxen som scriptet ligger på inte är när något ska isGrounded bli false
        isGrounded = false;
    }
}
