using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBehaviour : MonoBehaviour
{
    public Vector3 velocity;

    public float rotZ;
    float slice;

    // Start is called before the first frame update
    void Start()
    {
        slice = Random.Range(-100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        rotZ = (transform.rotation.eulerAngles.z + slice/5) * Mathf.Deg2Rad;
        velocity = new Vector2(Mathf.Sin(rotZ), Mathf.Cos(rotZ)) * 3;
        transform.position += velocity * Time.deltaTime;

        if (-GameManager.screenBounds.x > transform.position.x || transform.position.x > GameManager.screenBounds.x || 
            -GameManager.screenBounds.y > transform.position.y || transform.position.y > GameManager.screenBounds.y)
        {
            Destroy(this.gameObject);
        }
    }
}
