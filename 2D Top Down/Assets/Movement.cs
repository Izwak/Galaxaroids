using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float xVel = 0, yVel = 0;
        float speed = 2f;

        if (Input.GetKey(KeyCode.W))
        {
            yVel = speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            yVel = -speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            xVel = -speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            xVel = speed;
        }

        transform.position += new Vector3(xVel, yVel) * Time.deltaTime;
    }
}
