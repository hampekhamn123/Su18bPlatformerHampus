using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public int minimumScoreNeeded = 0;
    public string sceneToLoad = "SampleScene";

    private void OnTriggerEnter2D(Collider2D collision)
    {   //om objektet som scriptet ligger på kolliderar med ett objekt som har tagen "player" och om score från scriptet Coin är störe än eller lika med variabeln minimumScoreNeeded 
        if (collision.tag == "Player" && Coin.score >= minimumScoreNeeded)
        { //sätt score från scriptet Coin till 0 och ladda scenen sceneToLoad som är en variabel där vi har satt in vår scen.
            Coin.score = 0;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
