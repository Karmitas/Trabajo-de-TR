using UnityEngine;

public class CopyRotation : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        Vector3 currentEuler = transform.rotation.eulerAngles;
        Vector3 targetEuler = target.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(currentEuler.x, targetEuler.y, currentEuler.z);
    }
}
