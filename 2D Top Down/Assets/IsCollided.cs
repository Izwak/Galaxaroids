using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCollided : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collisin Entered");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger Entered");
    }
}