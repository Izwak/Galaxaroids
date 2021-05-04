using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBehaviour : MonoBehaviour
{
    public Vector3 velocity;

    public float rotZ;
    float slice;
    float speed = 5;
    float gravity = 0;

    // Start is called before the first frame update
    void Start()
    {
        slice = Random.Range(-100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        gravity -= 0.01f;

        rotZ = (transform.rotation.eulerAngles.z + slice/5) * Mathf.Deg2Rad;
        velocity = new Vector2(Mathf.Sin(rotZ), Mathf.Cos(rotZ) + gravity) * speed;
        transform.position += velocity * Time.deltaTime;

        if (-GameManager.screenBounds.x > transform.position.x || transform.position.x > GameManager.screenBounds.x || 
            -GameManager.screenBounds.y > transform.position.y || transform.position.y > GameManager.screenBounds.y)
        {
            Destroy(this.gameObject);
        }
    }
}
