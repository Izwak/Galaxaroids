using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile1 : MonoBehaviour
{
    public GameObject projetilePrefab;
    public Transform ship;

    int coolDown = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && coolDown <= 0)
        {
            GameObject newProjectile;
            newProjectile = Instantiate(projetilePrefab, new Vector2(ship.position.x, ship.position.y), ship.rotation);
            newProjectile.transform.SetParent(transform);

            coolDown = 30;
        }
        coolDown--;
    }
}
