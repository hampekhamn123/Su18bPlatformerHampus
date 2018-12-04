using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHorizontalMovement : MonoBehaviour
{
    public int platformSpeed = 3;

    public bool right = true;

    private Rigidbody2D rbody;

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
