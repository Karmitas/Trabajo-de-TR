using UnityEngine;
using TMPro;

public class RoundNumberShow : MonoBehaviour
{
    [Header("UI Elements")]
    public TMPro.TextMeshProUGUI roundText;
    public Animator anim;
    public GameObject rns;

    public void ChangedRound(int x)
    {
        if (!rns.activeSelf) { rns.SetActive(true); }
        roundText.text = "ROUND " + x.ToString();
        anim.SetTrigger("x");
    }
}
