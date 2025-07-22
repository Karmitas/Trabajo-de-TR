using UnityEngine;

public class RotateAroundYExe : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed of rotation in degrees per second

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
