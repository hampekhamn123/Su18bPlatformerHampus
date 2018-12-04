using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLockScript : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        if (PlatformHorizontalMovement.keyCollected == true)
        {
            Destroy(gameObject);
        }
    }
}
