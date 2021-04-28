using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    public GameObject Asteroid;
    int time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time++;
        if (time % 50 == 0)
        {
            Vector2 pos = new Vector2(Random.Range(-GameManager.screenBounds.x, GameManager.screenBounds.x), GameManager.screenBounds.y);
            GameObject newAsteroid = Instantiate(Asteroid, pos, new Quaternion());
            newAsteroid.transform.SetParent(transform);
        }
    }
}
