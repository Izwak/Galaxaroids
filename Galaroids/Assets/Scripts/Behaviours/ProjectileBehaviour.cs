using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public GameObject AsteroidParticalPrefab;

    float speed = 15;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float rotZ = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        Vector3 velocity = new Vector2(-Mathf.Sin(rotZ), Mathf.Cos(rotZ)) * speed;
        transform.position += velocity * Time.deltaTime;

        if (-GameManager.screenBounds.x > transform.position.x || transform.position.x > GameManager.screenBounds.x ||
            -GameManager.screenBounds.y > transform.position.y || transform.position.y > GameManager.screenBounds.y)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        print("Asteroid Hit");

        Instantiate(AsteroidParticalPrefab, collision.transform.position, new Quaternion());
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
    }
}
