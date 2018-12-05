using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public Sprite leverActive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //om objektets trigger kolliderar med ett objekt som har tagen Player skall den få en sprite som indikerar att levern är activated i spelet
        //KeyCollected från PLatformHorizontalMovement skall också bli true
        if (collision.tag == "Player")
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = leverActive;
            PlatformHorizontalMovement.keyCollected = true;

        }

    }
}
