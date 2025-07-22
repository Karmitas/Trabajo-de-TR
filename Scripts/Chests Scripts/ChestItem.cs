using UnityEngine;

public class ChestItem : MonoBehaviour
{

    public ChestController chestController;
    public ChestManagerSystem chestManagerSystem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chestManagerSystem = GameObject.FindGameObjectWithTag("ChestManager").GetComponent<ChestManagerSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RightHandInteractuable"))
        {
            if (chestController != null && chestManagerSystem != null)
            {
                chestController.InteractItem(0);
                chestManagerSystem.NextRound();
                chestManagerSystem.round.ArcadeMode();
            }
            else
            {
                Debug.LogError("ChestController or ChestManagerSystem is not assigned.");
            }
        }
    }
}

