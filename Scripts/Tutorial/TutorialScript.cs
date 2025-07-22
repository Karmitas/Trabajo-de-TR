using UnityEngine;
using TMPro;
using System.Collections;

public class TutorialScript : MonoBehaviour
{

    [Header("Tutorial Text")]
    public TextMeshPro tutorialText;

    public int tutorialID;

    public string[] tutorialTexts;

    public float letterDelay = 0.05f;

    [Header("Setup")]
    public Animator anim;

    [Space]
    public GameObject dagger;
    private bool y;

    [Space]
    public GameObject chargePoints;
    private bool z;

    [Space]
    public GameObject satanichanCajaDeMangos;
    private bool a;

    private Coroutine revealCoroutine;

    private int x;

    private float b = 3;


    void Start()
    {
        StartReveal();
        dagger.SetActive(false);
        chargePoints.SetActive(false);
        satanichanCajaDeMangos.SetActive(false);
    }

    void Update()
    {
        if (x != tutorialID)
        {
            x = tutorialID;
            StartReveal();
        }

        ScriptedEvents();
    }

    void ScriptedEvents()
    {
        if(!y)
        {
            dagger.SetActive(false);
        }

        if (!y && tutorialID == 10)
        {
            y = true;
            dagger.SetActive(true);
        }

        if (!z)
        {
            chargePoints.SetActive(false);
        }
        if (!z && tutorialID == 13)
        {
            z = true;
            chargePoints.SetActive(true);
        }

        if (!a)
        {
            satanichanCajaDeMangos.SetActive(false);
        }
        if (!a && tutorialID == 14)
        {
            a = true;
            satanichanCajaDeMangos.SetActive(true);
        }

        if (satanichanCajaDeMangos != null && satanichanCajaDeMangos.GetComponent<EnemyHealth>().hp <= 0)
        {
            Destroy(satanichanCajaDeMangos);
            anim.SetTrigger("Killed");
        }

        if(tutorialID == 26)
        {
            b -= Time.deltaTime;
            if (b <= 0)
            {
                GameObject.FindGameObjectWithTag("Data").GetComponent<Data>().nextScene = "MainMenu";
                UnityEngine.SceneManagement.SceneManager.LoadScene("LoadScene");
            }
        }
    }

    void StartReveal()
    {
        if (revealCoroutine != null)
            StopCoroutine(revealCoroutine);
        revealCoroutine = StartCoroutine(RevealTextCoroutine(tutorialTexts[tutorialID]));
    }

    IEnumerator RevealTextCoroutine(string fullText)
    {
        tutorialText.text = "";
        for (int i = 0; i < fullText.Length; i++)
        {
            tutorialText.text += fullText[i];
            yield return new WaitForSeconds(letterDelay);
        }
    }
}
