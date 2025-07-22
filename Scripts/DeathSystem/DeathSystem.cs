using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSystem : MonoBehaviour
{
    [Header("Settings")]
    public float timeToDie = 4f;

    [Header("Scripts References")]
    public Data data;
    public PlayerHealth hp;

    [Header("Skybox")]
    public Material deathSkybox;

    private bool x;

    void Start()
    {
        if (data == null)
        {
            data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
        }
        if (hp == null)
        {
            hp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        }
    }

    void LateUpdate()
    {
        if (hp.currentHealth <= 0)
        {
            RenderSettings.skybox = deathSkybox;
            Animator anim = GameObject.FindGameObjectWithTag("DamageFeedback").GetComponent<Animator>();
            anim.SetTrigger("Dead");
            x = true;
        }

        if (x)
        {
            timeToDie -= Time.deltaTime;

            if (timeToDie <= 0)
            {
                data.nextScene = "MainMenu";
                SceneManager.LoadScene("LoadScene");
            }
        }
    }
}
