using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    float speed = 15;
    int tick = 0;

    // Update is called once per frame
    void Update()
    {
        tick++;

        // Set projectile to angle of ship
        float rotZ = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        Vector3 velocity = new Vector2(-Mathf.Sin(rotZ), Mathf.Cos(rotZ)) * speed;
        transform.position += velocity * Time.deltaTime;

        // Destroy when projectile leaves the screen
        if (-GameManager.screenBounds.x > transform.position.x || transform.position.x > GameManager.screenBounds.x ||
            -GameManager.screenBounds.y > transform.position.y || transform.position.y > GameManager.screenBounds.y)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Asteroids") // Stops projectile accidentally colliding with ship
        {
            print("Asteroid Hit");

            // Simulate Asteroid Explosion
            GameObject newParticleSystem;
            newParticleSystem = Instantiate(GameManager.AsteroidParticlePrefab, collision.transform.position, new Quaternion());
            newParticleSystem.transform.SetParent(GameManager.AsteroidParticleFolder);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

            GameManager.score++;
        }
    }
}
