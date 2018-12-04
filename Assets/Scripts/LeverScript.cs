using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public Sprite leverActive;
    //public Transform t;
    //public GameObject myCoin;

    public SpawnCoin spawnCoinScript;

    void Start()
    {

    }
    
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = leverActive;
            PlatformHorizontalMovement.keyCollected = true;
            spawnCoinScript.SpawnCoins();

        }

    }
}
