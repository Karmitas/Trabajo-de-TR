using UnityEngine;

public class Comodidades : MonoBehaviour
{

    [Header("Set")]
    public GameObject canva;
    public GameObject mandoDerecho;
    public GameObject mandoIzquierdo;

    void Start()
    {
        canva.SetActive(true);
        mandoDerecho.SetActive(true);
        mandoIzquierdo.SetActive(true);
    }
}
