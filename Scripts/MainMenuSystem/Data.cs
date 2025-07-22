using UnityEngine;

public class Data : MonoBehaviour
{
    [Header("Data")]
    public int volume = 1;
    public bool lowQuality = false;
    public string nextScene = "";
    public bool arcadeMode = false;


    private static Data instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
