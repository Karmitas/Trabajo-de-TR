using UnityEngine;

public class SpawnThing : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject spawnPosition;
    public GameObject thingToSpawn;

    [Header("For Animation")]
    public bool spawnOnAnimation = false;

    private int x;
    private float y = 1f;

    void Start()
    {
        x = 1;
    }
    void Update()
    {
        if (spawnOnAnimation && x == 1)
        {
            Spawn();
        }

        if (x != 1)
        {
            y -= Time.deltaTime;
            if (y <= 0)
            {
                y = 1f;
                x = 1;
            }
        }
    }

    void Spawn()
    {
        thingToSpawn.transform.position = spawnPosition.transform.position;
        thingToSpawn.transform.rotation = spawnPosition.transform.rotation;

        Instantiate(thingToSpawn);
        x--;
        spawnOnAnimation = false;
    }
}
