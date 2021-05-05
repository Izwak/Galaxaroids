using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBehaviour : MonoBehaviour
{
    public Vector3 velocity;

    public float rotation;
    float slice;
    float speed = 5;
    float gravity = 0;

    int time = 0;


    Color smokeColour;

    // Start is called before the first frame update
    void Start()
    {
        // Set starting rotation
        slice = Random.Range(-100, 100);
        rotation = (transform.rotation.eulerAngles.z + slice / 5) * Mathf.Deg2Rad;

        // Set the starting position of the smoke closer to the back of the rocket
        Vector3 testVector = new Vector2(Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad), Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad));
        transform.position += testVector * 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        gravity -= 0.01f;
        time += 6;

        if (time > 255)
            time = 255;

        // Set velocity
        velocity = new Vector2(Mathf.Sin(rotation), Mathf.Cos(rotation) + gravity) * speed;
        transform.position += velocity * Time.deltaTime;

        // Destroy when out of bounds
        if (-GameManager.screenBounds.x > transform.position.x || transform.position.x > GameManager.screenBounds.x || 
            -GameManager.screenBounds.y > transform.position.y || transform.position.y > GameManager.screenBounds.y)
        {
            Destroy(this.gameObject);
        }


        // Setting Colour
        if (time * Time.deltaTime < 1)
            smokeColour = Color.Lerp(Color.yellow, Color.red, time * Time.deltaTime);
        else
            smokeColour = Color.Lerp(Color.red, Color.grey, time * Time.deltaTime - 1);

        GetComponent<SpriteRenderer>().color = smokeColour;
    }
}
