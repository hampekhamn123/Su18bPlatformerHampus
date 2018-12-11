using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossHealthScript : MonoBehaviour
{
    private TextMeshPro text;

    public BossFrog bossFrog;

    void Start()
    {
        text = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        text.text = string.Format("Health: {0:00}", bossFrog.frogHP);

    }
}
