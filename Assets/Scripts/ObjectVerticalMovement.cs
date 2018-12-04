using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectVerticalMovement : MonoBehaviour
{
    public bool down = true;

    private Rigidbody2D rbody;

    public int speed = 2;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (down == true)
        {
            rbody.velocity = -(Vector2)transform.up * speed;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            rbody.velocity = (Vector2)transform.up * speed;
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetKey(KeyCode.C))
            rbody.velocity = (Vector2)transform.up * 0;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   //när något kolliderar med objektet som scriptet ligger på händer följande if sats.
        //om objektet som koliderar med objektet som scriptet ligger på har tagen "invisibleWall" skall down bli lika med false
        if (collision.tag == "InvisibleWall")
        {
            down = !down;
        }
    }
}
