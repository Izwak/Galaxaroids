using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerBody;

    float angle;
    int tick = 0;

    // Update is called once per frame
    void Update()
    {
        tick++;

        Vector2 pos = transform.position;
        Vector2 direction = GameManager.mousePos - pos;

        // Calculate rotation
        float sign = (direction.x >= 0) ? -1 : 1;
        angle = Vector2.Angle(Vector2.up, direction) * sign;
        playerBody.rotation = Quaternion.Euler(0, 0, angle);

        // Calculate position
        float velX = Mathf.Clamp(direction.x * 2, -10, 10);
        transform.position += new Vector3(velX, 0) * Time.deltaTime;

        // Keep ship on screen
        float clampedX = Mathf.Clamp(transform.position.x, -GameManager.screenBounds.x, GameManager.screenBounds.x);
        transform.position = new Vector2(clampedX, transform.position.y);

        // Spawn smoke
        if (tick % 3 == 0 && (playerBody.rotation.eulerAngles.z < 90 || playerBody.rotation.eulerAngles.z > 270))
        {
            GameObject newSmog = Instantiate(GameManager.SmogPrefab, playerBody.position, Quaternion.Euler(0, 0, 180 - angle));
            newSmog.transform.SetParent(GameManager.SmogFolder);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Asteroids")
        {
            GameManager.health--;
            GameObject newParticle;
            newParticle = Instantiate(GameManager.AsteroidParticlePrefab, collision.transform.position, new Quaternion());
            newParticle.transform.SetParent(GameManager.AsteroidParticleFolder);
            Destroy(collision.gameObject);
        }


        //print("Health: " + GameManager.health);
    }
}
