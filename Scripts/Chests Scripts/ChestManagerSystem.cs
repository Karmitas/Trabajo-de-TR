using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class ChestManagerSystem : MonoBehaviour
{
    [Header("Parameters")]
    public RoundManager round;

    [Header("Chests Gameobjects")]
    public List<GameObject> chests = new List<GameObject>();

    private RoundNumberShow rns;
    private int currentRound;

    private bool x;

    void Start()
    {
        SetActiveChest(false);
        if (round == null)
        {
            round = GameObject.FindGameObjectWithTag("EnemySpawnerSystem").GetComponent<RoundManager>();
        }

        if (rns == null)
        {
            rns = GameObject.FindGameObjectWithTag("RoundNumberShowManager").GetComponent<RoundNumberShow>();
        }
    }

    void LateUpdate()
    {
        currentRound = round.currentRound;

        if (currentRound == 0)
        {
            if (!x)
            {
                EndedRound();
            }
        }

        if (round.enemiesAlive >= 0 && round.currentRound != 0 || round.totalEnemiesInRound[round.currentRound] >= 0 && round.currentRound != 0)
        {
            if (x)
            {
                x = false;
            }
        }
    }

    public void EndedRound()
    {
        foreach (GameObject chest in chests)
        {
            chest.GetComponent<ChestController>().SpawnRandomItem();
        }
        SetActiveChest(true);
        x = true;
    }

    public void SetActiveChest(bool activeStatus)
    {
        foreach (GameObject chest in chests)
        {
            if (chest.activeSelf != activeStatus)
            {
                chest.SetActive(activeStatus);
            }
        }
    }

    [ContextMenu("Next Round")]
    public void NextRound()
    {
        round.currentRound++;
        rns.ChangedRound(round.currentRound);
        round.x = false;
        SetActiveChest(false);
    }
}
