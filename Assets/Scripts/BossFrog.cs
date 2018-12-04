using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFrog : MonoBehaviour
{
    private Rigidbody2D rbody;

    public Sprite inAir;
    public Sprite notInAir;
    public GroundChecker GroundChecker;
    public float jumpLength = 2;
    public float jumpHight = 5;
    public int frogHP = 3;
    private float timer = 0;
    private float timesJumped = 0;
    private bool left = true;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }



    private void FixedUpdate()
    {
        if (GroundChecker.isGrounded == 1)
            timer += Time.deltaTime;

        if (timesJumped == 4)
            left = !left;

        if (GroundChecker.isGrounded == 1 && timer > 2 && left == true)
        {
            timer = 0;
            rbody.AddForce((-Vector3.right) * jumpLength, ForceMode2D.Impulse);
            rbody.AddForce((Vector3.up) * jumpHight, ForceMode2D.Impulse);
            timesJumped += 1;
            transform.localScale = new Vector3(1, 1, 1);
        }

        //hoppar åt höger
        if (GroundChecker.isGrounded == 1 && timer > 2 && left == false)
        {
            timer = 0;
            rbody.AddForce((Vector3.right) * jumpLength, ForceMode2D.Impulse);
            rbody.AddForce((Vector3.up) * jumpHight, ForceMode2D.Impulse);
            timesJumped += 1;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (GroundChecker.isGrounded == 1)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = notInAir;
        else
            this.gameObject.GetComponent<SpriteRenderer>().sprite = inAir;

    }
}
