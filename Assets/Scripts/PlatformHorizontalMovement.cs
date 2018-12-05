using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHorizontalMovement : MonoBehaviour
{
    //tog bort detta script eftersom att jag ändrade mig om sista nivån och inte hade med objektet i nivån, men använder en variabel i scriptet som jag inte visste vart det skulle ligga så de får ligga kvar
    public int platformSpeed = 3;

    public bool right = true;

    private Rigidbody2D rbody;
    //gör att variabeln KeyCollected kan kommas åt från flera scripts det är det ända relevanta efterom att inget utav resterande funktioner används men de fungerar på samma sätt som i objectVerticalMovement
    public static bool keyCollected = false;

    void Start()
    {
       rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (right == true && keyCollected == true)
        {
            rbody.velocity = (Vector2)transform.right * platformSpeed;
        }
        else if (right == false && keyCollected == true)
            rbody.velocity = -(Vector2)transform.right * platformSpeed;

        if (Input.GetKey(KeyCode.C))
        {
            rbody.velocity = (Vector2)transform.right * 0;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "InvisibleWall")
        {
            print("hej");
            right = !right;
        }
    }
}
