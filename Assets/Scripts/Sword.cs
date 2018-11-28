using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Rigidbody2D rbody;

    private bool lookingRight = true;

    public int swingSpeed = 500;

    private void FixedUpdate()
    {
        if (transform.rotation.z <= -0.8 && lookingRight == true || (Input.GetKeyUp(KeyCode.V)))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (transform.rotation.z >= 0.8 && lookingRight == false || (Input.GetKeyUp(KeyCode.V)))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.V) && lookingRight == true)
        {
            transform.Rotate(0, 0, -swingSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.V) && lookingRight == false)
        {
            transform.Rotate(0, 0, swingSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2((rbody.position.x - 0.32f), (rbody.position.y - 0.55f));
            lookingRight = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2((rbody.position.x + 0.32f), (rbody.position.y - 0.55f));
            lookingRight = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
