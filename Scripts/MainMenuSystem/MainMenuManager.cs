using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MainMenuManager : MonoBehaviour
{
    [Header("Settings")]
    public string startGameSceneName;
    public string arcadeGameSceneName;
    public string tutorialSceneName;

    [Space]
    public GameObject sureObject;
    public GameObject settingsParameters;

    [Space]
    public List<GameObject> soundBars;
    public GameObject low;

    [Space]
    public Data data;


    void Start()
    {
        sureObject.SetActive(false);
        settingsParameters.SetActive(false);
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();

        ChangeVolume(1); // Initialize sound bars based on default volume
        low.GetComponent<Renderer>().material.color = Color.grey;
    }

    public void PlayerReacted(int i)
    {
        if (i == 0)
        {
            data.nextScene = startGameSceneName;
            data.arcadeMode = false;
            SceneManager.LoadScene("LoadScene");
        }
        if (i == 1)
        {
            data.nextScene = tutorialSceneName;
            SceneManager.LoadScene("LoadScene");
        }
        if (i == 2)
        {
            data.nextScene = startGameSceneName;
            data.arcadeMode = true;
            SceneManager.LoadScene("LoadScene");
        }
        if (i == 3)
        {
            sureObject.SetActive(!sureObject.activeSelf);
        }
        if (i == 4)
        {
            settingsParameters.SetActive(!settingsParameters.activeSelf);
        }
    }

    public void ChangeVolume(int i)
    {
        if (i == 0)
        {
            data.volume++;
        }
        if (i == 1)
        {
            data.volume--;
        }

        if (data.volume == 0)
        {
            data.volume = 1;
        }
        if (data.volume > 5)
        {
            data.volume = 5;
        }

        for (int j = 0; j < soundBars.Count; j++)
        {
            if (j < data.volume)
            {
                soundBars[j].SetActive(true);
            }
            else
            {
                soundBars[j].SetActive(false);
            }
        }
    }

    public void ChangeQuality()
    {
        data.lowQuality = !data.lowQuality;
        if (data.lowQuality)
        {
            low.GetComponent<Renderer>().material.color = Color.white;
        }
        else
        {
            low.GetComponent<Renderer>().material.color = Color.grey;
        }
    }
}
