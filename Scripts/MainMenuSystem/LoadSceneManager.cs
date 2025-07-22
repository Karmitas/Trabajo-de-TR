using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSceneManager : MonoBehaviour
{
    public Data data;

    private void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
        if (data == null)
        {
            LoadSceneAsync("MainMenu");
        }
        else
        {
            LoadSceneAsync(data.nextScene);
        }
    }

    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;

        while (asyncLoad.progress < 0.9f)
        {
            yield return null;
        }

        yield return new WaitForSeconds(5f);

        asyncLoad.allowSceneActivation = true;
    }
}
