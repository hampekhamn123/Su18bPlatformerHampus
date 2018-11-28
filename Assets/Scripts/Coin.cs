using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Static gör att du kan ha ett script på flera olika objekt eftersom att den kan hämta värdet från objekt med olika värden.
    public static int score;

    public int amount = 1;

    private float spinSpeed = 180;

    private void Update()
    {   //Roterar coinet runt sin Y axel i realtid och inte efter fps (Time.deltaTime)
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   /*om objektet som scriptet ligger på kolliderar med ett objekt som har tagen "player" skall score variabeln ökas med det värde som objektet har gameobjektet. 
        scriptet ligger på skall också förstöras*
         */
        if (collision.tag == "Player")
        {
            Coin.score += amount;
            Destroy(gameObject);
        }
    }
}
