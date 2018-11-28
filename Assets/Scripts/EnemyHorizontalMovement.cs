using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontalMovement : MonoBehaviour
{
    public float speed = 2f;
    public bool left = true;
    //Gör att värdet jumpBlock är samma på alla objekt med scriptet
    public static bool jumpBlock = false;

    private Rigidbody2D rbody;

    // Use this for initialization
    void Start()
    {   //kallar på componenten rigid body från objektet som scriptet ligger på.
        rbody = GetComponent<Rigidbody2D>();
    }
    //uppdaterar framesen 50 gånger per sekund används när man jobbar med fysik.
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.C))
        {   //om Knappen C är nedtryck skall transform (som vi konverterar till en Vector2 med (Vecktor2)) sättas till 0
            rbody.velocity = (Vector2)transform.right * 0;
            //boolen jumpBlock sätts till true vilket används i PlayerMovement scriptet
            jumpBlock = true;

        }
        else
        {   //om inte knappen C är nedtryckt kollar den följande if sats
            if (left == true)
            { /*om left är lika med true(vilket är dess standard värde) skall objektet som scriptet ligger på ändra hastighet.
               Rigidbodyn som vi kallade på nu har en hastighet, vi ändrar den hastigheten till  negativ transform(som vi ändrar till en Vecktor2 med (Vecktor2))
               vi gör hastigheten negativ eftersom att det är .right för att den har utgångslägge med spriten till vänster. Vi multiplicerar
               hastigheten med den bestämda variabeln speed
              */

                rbody.velocity = -(Vector2)transform.right * speed;
                //ändrar skalan på objektet till det normala
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {   //om left inte är lika med true händer samma sak som ovan men värdet blir positivt eftersom vi inte har ett - tecken innan
                rbody.velocity = (Vector2)transform.right * speed;
                //ändrar skallan i x axeln till negativt vilket flippar objektet och hitboxen
                transform.localScale = new Vector3(-1, 1, 1);
            }
            //om inte C är nedtryckt blir jumpBlock false
            jumpBlock = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   //när något kolliderar med objektet som scriptet ligger på händer följande if sats.
        //om objektet som koliderar med objektet som scriptet ligger på har tagen "invisibleWall" skall left bli lika med false
        if (collision.tag == "InvisibleWall")
        {
            left = !left;
        }
        //om objektet som kolliderar med musen har tagen Weapon så försvinner musen
        if (collision.tag == "Weapon")
        {
            Destroy(gameObject);
        }
    }
}
