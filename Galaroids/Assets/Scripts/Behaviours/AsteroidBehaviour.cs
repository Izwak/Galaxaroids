using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    public Vector2 vel;
    public float spin, scale, rotation;
    int maxVel = 15;

    // Start is called before the first frame update
    void Start()
    {
        // Set Random Velocity, starting rotation and spin
        rotation = Random.Range(0, 360);
        spin = Random.Range(-10, 10);
        scale = Random.Range(10, 30);

        vel = new Vector2(Random.Range(-maxVel, maxVel) / 3, -Random.Range(maxVel / 3, maxVel));
        transform.localScale = new Vector2(scale, scale) / 10;

        // Adjust position to not be in frame when spawned
        transform.position -= new Vector3(0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        // Asteroid rotation and position
        transform.position += new Vector3(vel.x, vel.y) * Time.deltaTime;
        rotation += spin * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, rotation * 10) ;

        // Destroy when out of bounds
        if (transform.position.y < -GameManager.screenBounds.y - 1)
            Destroy(this.gameObject);
    }
}
