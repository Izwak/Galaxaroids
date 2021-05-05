using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject asteroidPrefab, projectilePrefab, smogPrefab, asteroidParticlePrefab;
    public Transform asteroidFolder, projectileFolder, smogFolder, asteroidParticleFolder;
    public static GameObject AsteroidPrefab, ProjectilePrefab, SmogPrefab, AsteroidParticlePrefab;
    public static Transform AsteroidFolder, ProjectileFolder, SmogFolder, AsteroidParticleFolder;

    public static Vector2 mousePos;
    public static Vector2 screenBounds;

    public static int tick = 0;
    public static int score = 0;
    public static int health = 3;

    [Range(1, 10)] public int uselessSlider;

    // Start is called before the first frame update
    void Start()
    {
        // Set the static Objects and transforms
        AsteroidPrefab = asteroidPrefab;
        ProjectilePrefab = projectilePrefab;
        SmogPrefab = smogPrefab;
        AsteroidParticlePrefab = asteroidParticlePrefab;
        AsteroidFolder = asteroidFolder;
        ProjectileFolder = projectileFolder;
        SmogFolder = smogFolder;
        AsteroidParticleFolder = asteroidParticleFolder;

        Cursor.visible = false;

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        tick++;

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
