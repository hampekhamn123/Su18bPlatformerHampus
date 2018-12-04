using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    public GameObject myCoin;
    public Transform t;

    public void SpawnCoins()
    {
        Instantiate(myCoin,t.localPosition,Quaternion.identity);
    }
}
