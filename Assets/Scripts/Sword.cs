using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Rigidbody2D rbody;

    private bool lookingRight = true;

    public int swingSpeed = 500;

    private void Start()
    {
        //rbody = transform.parent.GetComponent<Rigidbody2D>();
        //hittar players rigidbody
        rbody = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    
    private void FixedUpdate()
    {   //om svärdets rotationsvärde är mindre än -0,8 och att player kollar åt höger eller att V inte är nedtryckt händer följande
        if (transform.rotation.z <= -0.8 && lookingRight == true || (Input.GetKeyUp(KeyCode.V)))
        {   //sätter vinkeln på svärdet till 0 i alla axlar
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (transform.rotation.z >= 0.8 && lookingRight == false || (Input.GetKeyUp(KeyCode.V)))
        {   //annars om rotationen är större än 0,8 och player kollar åt vänster (lookingRight == false) eller att V inte är nedtryckt händer samma sak, jag har 2 olika så att den reagerar eftersom att vinkeln blir positiv om den står åt andra hållet
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.V) && lookingRight == true)
        {   //om V är nedtryckt och player står åt höger skall svärdet rotera negativt alltså medurs. detta görs i per sekund och inte per fps för att inte lag ska förstöra
            transform.Rotate(0, 0, -swingSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.V) && lookingRight == false)
        {   //annars om V är nedtryckt och player inte kollar åt höger skall den göra samma sak men rotera svärdet åt andra hållet.
            transform.Rotate(0, 0, swingSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {   //om A trycks ner skall svärdets positions bli -0.32 jämnfört med players x position och -0.55 jämnfört med players y position
            transform.position = new Vector2((rbody.position.x - 0.32f), (rbody.position.y - 0.55f));
            //looking right sätts sim negativ eftersom att spelaren nu kollar åt vänster
            lookingRight = false;
        }

        if (Input.GetKey(KeyCode.D))
        {   //samma sak som ovan fast mottsat håll om spelar ska förflyta sig åt höger.
            transform.position = new Vector2((rbody.position.x + 0.32f), (rbody.position.y - 0.55f));
            lookingRight = true;
        }
    }
}
