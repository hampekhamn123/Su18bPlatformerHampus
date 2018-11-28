using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI text;

    // Use this for initialization
    void Start()
    {   //hämtar TextMeshPro Componenten från samma objekt som scriptet ligger på.
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {   //Kallar på text variabeln från add on TextMeshProGui och skriver ut score med samma värde som Score från scriptet Coin. 
        text.text = string.Format("Score: {0:0000}", Coin.score);
    }
}
