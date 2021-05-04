using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerBody;
    public GameObject SmogPrefab;
    public Transform SmogFolder;

    public float angle;
    Vector2 pos;

    int tick = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        Vector2 direction = GameManager.mousePos - pos;

        float sign = (direction.x >= 0) ? -1 : 1;

        angle = Vector2.Angle(Vector2.up, direction) * sign;

        playerBody.rotation = Quaternion.Euler(0, 0, angle);

        float velX = Mathf.Clamp(direction.x * 2, -10, 10);

        transform.position += new Vector3(velX, 0) * Time.deltaTime;

        float clampedX = Mathf.Clamp(transform.position.x, -GameManager.screenBounds.x, GameManager.screenBounds.x);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        tick++;
        if (tick % 3 == 0 && (playerBody.rotation.eulerAngles.z < 90 || playerBody.rotation.eulerAngles.z > 270))
        {
            GameObject newSmog = Instantiate(SmogPrefab, new Vector2(playerBody.position.x, playerBody.position.y), Quaternion.Euler(0, 0, 180 - angle));
            newSmog.transform.SetParent(SmogFolder);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
            print("Player Collision Detected");
    }
}
