using UnityEngine;

public class SetMusicVolume : MonoBehaviour
{
    public Data data;
    public AudioSource musicSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();

        if (musicSource == null)
        {
            musicSource = gameObject.GetComponent<AudioSource>();
        }

        if (data == null)
        {
            musicSource.volume = 0.1f;
        }
        else
        {
            musicSource.volume = data.volume / 5f;
        }
    }

    private void LateUpdate()
    {
        if (data == null)
        {
            musicSource.volume = 0.1f;
        }
        else
        {
            musicSource.volume = data.volume / 5f;
        }
    }
}
