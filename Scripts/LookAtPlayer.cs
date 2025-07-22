using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.LookAt(GameObject.FindGameObjectWithTag("MainCamera").transform.position);
    }
}
