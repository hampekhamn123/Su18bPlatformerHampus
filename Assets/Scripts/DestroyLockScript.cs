using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLockScript : MonoBehaviour
{


    void Update()
    {
        //om KeyCollected variabeln från PlatformHorizontalMovement är true skall objektet som scriptet ligger på försvinna 
        if (PlatformHorizontalMovement.keyCollected == true)
        {
            Destroy(gameObject);
        }
    }
}
