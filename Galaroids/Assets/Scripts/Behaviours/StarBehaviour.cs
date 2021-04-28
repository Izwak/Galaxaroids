using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehaviour : MonoBehaviour
{
    public float rand;

    public float scale;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, 100);
        // Set scale to be an expenential distrubtion so there are more smaller stars then larger ones
        scale = Mathf.Pow(0.93f, (-0.93f * (rand - 20))) / 400 + 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector2(scale, scale);
        transform.position += new Vector3(0, -scale * 2) * Time.deltaTime;

        // When Stars reach the bottom of the screen send them to the top at a random x to make the stars look more random
        if(transform.position.y < -GameManager.screenBounds.y)
        {
            transform.position = new Vector2(Random.Range(-GameManager.screenBounds.x, GameManager.screenBounds.x), GameManager.screenBounds.y);
        }
    }
}
