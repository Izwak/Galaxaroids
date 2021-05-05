using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    int tick = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tick++;
        if (tick % 20 == 0)
        {
            Vector2 pos = new Vector2(Random.Range(-GameManager.screenBounds.x, GameManager.screenBounds.x), GameManager.screenBounds.y);
            GameObject newAsteroid = Instantiate(GameManager.AsteroidPrefab, pos, new Quaternion());
            newAsteroid.transform.SetParent(transform);
        }
    }
}
