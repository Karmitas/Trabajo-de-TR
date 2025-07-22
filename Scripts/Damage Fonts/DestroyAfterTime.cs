using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{

    public float lifetime = 2f; // Time in seconds before the object is destroyed

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime; // Decrease lifetime by the time passed since last frame
        if (lifetime <= 0f) // Check if lifetime has reached zero
        {
            Destroy(gameObject); // Destroy the game object
        }
    }
}
