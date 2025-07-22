using UnityEngine;

public class MusicSystem : MonoBehaviour
{

    [Header("Set")]
    public RoundManager roundManager;
    public AudioSource musicSource;
    public AudioSource changeStateSound;

    [Header("Parameters")]
    public AudioClip chillMusic;
    public AudioClip combatMusic;

    private bool x;
    private bool y;

    void Start()
    {
        roundManager = GameObject.FindGameObjectWithTag("EnemySpawnerSystem").GetComponent<RoundManager>();
    }
    void Update()
    {
        if (roundManager == null)
        {
            Debug.LogError("RoundManager is not assigned in MusicSystem.");
            return;
        }
        else
        {
            if (roundManager.enemiesAlive == 0 && roundManager.totalEnemiesInRound[roundManager.currentRound] == 0)
            {
                x = false;
            }
            else
            {
                x = true;
            }

            if (y != x)
            {
                if (!x) { musicSource.clip = chillMusic; musicSource.Play(); }
                else { musicSource.clip = combatMusic; musicSource.Play(); }

                changeStateSound.Play();
                y = x;
            }
        }
    }
}
