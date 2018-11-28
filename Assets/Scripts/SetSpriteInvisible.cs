using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpriteInvisible : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {   //kallar på komponenten spriteRenderer från objektet som scriptet ligger på och gör det till false. vilket gör att objektet slutar synas när spelet startas
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
