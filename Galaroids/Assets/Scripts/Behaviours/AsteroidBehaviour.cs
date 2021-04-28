using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    public Vector2 vel;
    public float spin;
    public float scale;

    public float rotation; 
    // Start is called before the first frame update
    void Start()
    {
        vel = new Vector2(Random.Range(-10, 10) / 3, -Random.Range(3, 10));
        rotation = Random.Range(0, 360);
        spin = Random.Range(-10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localScale = new Vector2(scale, scale) * Time.deltaTime;
        transform.position += new Vector3(vel.x, vel.y) * Time.deltaTime;
        rotation += spin * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, rotation * 10) ;


        if (transform.position.y < -GameManager.screenBounds.y)
            Destroy(this.gameObject);
    }
}
