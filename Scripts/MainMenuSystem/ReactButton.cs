using UnityEngine;

public class ReactButton : MonoBehaviour
{
    public int buttonIndex;

    public MainMenuManager mainMenuManager;

    void Start()
    {
        if (mainMenuManager == null)
        {
            mainMenuManager = GameObject.FindGameObjectWithTag("MainMenuManager").GetComponent<MainMenuManager>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RightHandInteractuable"))
        {
            if (buttonIndex != 5 || buttonIndex != 6 || buttonIndex != 7)
            {
                mainMenuManager.PlayerReacted(buttonIndex);
            }
            if (buttonIndex == 5)
            {
                mainMenuManager.ChangeVolume(0);
            }
            if (buttonIndex == 6)
            {
                mainMenuManager.ChangeVolume(1);
            }
            if (buttonIndex == 7)
            {
                mainMenuManager.ChangeQuality();
            }
            if (buttonIndex == 8)
            {
                Application.Quit();
            }
        }
    }
}
