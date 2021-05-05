using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile1 : MonoBehaviour
{
    public Transform ship;

    int coolDown = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coolDown--;

        // Spawn projectile
        if (Input.GetKeyDown(KeyCode.Space) && coolDown <= 0)
        {
            GameObject newProjectile;
            newProjectile = Instantiate(GameManager.ProjectilePrefab, ship.position, ship.rotation);
            newProjectile.transform.SetParent(transform);

            coolDown = 0;
        }
    }
}
