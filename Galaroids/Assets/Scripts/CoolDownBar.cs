using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownBar : MonoBehaviour
{
    public Image[] bars;

    int barCount = 7;

    int tick = 140;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tick < 140)
            tick++;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (tick > 10)
                tick -= 30;
        }


        for (int i = 0; i < barCount; i++)
        {
            bars[i].enabled = i < tick / 20;
        }
    }
}
