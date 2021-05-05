using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image[] healthImages;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            // Health Points only visible if 
            //healthImages[i].enabled = i <= GameManager.health;

            if (i >= GameManager.health)
                healthImages[i].enabled = false;
            else
                healthImages[i].enabled = true;
        }
    }
}
