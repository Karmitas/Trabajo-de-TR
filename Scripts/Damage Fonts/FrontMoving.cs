using UnityEngine;

public class FrontMoving : MonoBehaviour
{

    public float speed = 5f; // Speed of the object

    void Update()
    {
        transform.Translate(0,0,speed * Time.deltaTime);
    }
}
