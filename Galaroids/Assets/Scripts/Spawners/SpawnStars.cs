using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStars : MonoBehaviour
{
    public GameObject StarPrefab;
    public int starCount = 500;

    // Start is called before the first frame update
    void Start()
    {

        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        for (int i = 0; i < starCount; i++)
        {
            // Position is set to randomly on Screen
            Vector3 starPosition = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), Random.Range(-screenBounds.y, screenBounds.y));
            GameObject newStar = Instantiate(StarPrefab, starPosition, new Quaternion());
            newStar.transform.SetParent(transform);
        }
    }
}
