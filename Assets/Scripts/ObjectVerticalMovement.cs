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
        //om down är true skall velocityn på transform.up som vi gör om till en vector 2 multipliceras med speed denns local scale skall också hållas till 1, 1, 1 eftersom att den annars ville flipa vi ändrad kurs
        if (down == true)
        {
            rbody.velocity = -(Vector2)transform.up * speed;
            transform.localScale = new Vector3(1, 1, 1);
        }
        //om down inte är true utan något annat (false) händer samma sak skall den färdas uppåt fast positivt istället för negativt som ovan
        else
        {
            rbody.velocity = (Vector2)transform.up * speed;
            transform.localScale = new Vector3(1, 1, 1);
        }
        //om C är nedtryckt skall transform.up som är omgjort till en vector2 multipliceras med 0 och alltså stå still
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
