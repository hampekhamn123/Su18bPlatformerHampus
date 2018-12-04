using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpSpeed = 12f;

    public GroundChecker groundCheck;

    private Rigidbody2D rbody;

    public EnemyHorizontalMovement EnemyHorizontalMovement;

    // Use this for initialization
    void Start()
    {   //kallar vi componenten rigidbody från det objektet som scriptet ligger på
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   //ändrar hastigheten som rigidbodyn rör sig till horizontal alltså 1 om du trycker på d och -1 om du trycker på a
        //man multiplicerar 1 eller -1 med sin önskade movementspeed, hastigheten i Y axeln består.
        rbody.velocity = new Vector2(
            Input.GetAxisRaw("Horizontal") * moveSpeed,
            rbody.velocity.y);

        if (Input.GetButtonDown("Jump") && EnemyHorizontalMovement.jumpBlock == false)
            //om knappen jump vilket är space och jumoBlock variabeln från EnemyHorizontalMovement är lika med false kollar den följande if sats
            if (groundCheck.isGrounded > 0 || groundCheck.jumpValue <= 1)
            {   //om isGrounded från groundcheck scriptet är true eller om jumpValue från Groundcheck är lika med eller mindre än 1 gäller följande
                {   //rbodyns hastighet ändras till en ny Vector2 med samma x axel men den får en kraft i Y axeln beroende på din bestämda jumpSpeed
                    rbody.velocity = new Vector2(
                        rbody.velocity.x,
                        jumpSpeed);
                    //jumpValue från scriptet groundCheck får +1 i värde.
                    groundCheck.jumpValue += 1;
                }
            }
    }
}
