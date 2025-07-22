using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class ChestController : MonoBehaviour
{
    [Header("Chest ID")]
    public int chestID; // Unique identifier for the chest, 0 = left 1 = middle 2 = right

    [Header("Upgrade ID")]
    public int iID;

    [Header("Effects")]
    public float addDamage;
    public float addLifesteal;
    public float addHealth;
    public float addHealthRegen;

    [Header("Chest Items")]
    public List<GameObject> items = new List<GameObject>();
    public List<GameObject> effectsUpgrades = new List<GameObject>();

    [Header("Weapons in Game")]
    public PlayerWeaponManager playerWeaponManager;

    [Header("Scripts")]
    public RoundManager roundManager;

    void Start()
    {
        playerWeaponManager = GameObject.FindGameObjectWithTag("PlayerDamage").GetComponent<PlayerWeaponManager>();
        roundManager = GameObject.FindGameObjectWithTag("EnemySpawnerSystem").GetComponent<RoundManager>();
    }

    private void Update()
    {
        ItemSpawn();
    }

    private void LateUpdate()
    {
        if (playerWeaponManager == null)
        {
            playerWeaponManager = GameObject.FindGameObjectWithTag("PlayerDamage").GetComponent<PlayerWeaponManager>();
        }
    }

    public void InteractItem(int x)
    {
        if (x == 0)
        {
            if (roundManager.currentRound == 0)
            {
                playerWeaponManager.weaponValue = iID;
            }
            else if (roundManager.currentRound != 0 && chestID == 0)
            {
                playerWeaponManager.weaponValue = iID;
            }
            else if (roundManager.currentRound != 0 && chestID == 1 || roundManager.currentRound != 0 && chestID == 2)
            {
                // Add damage
                if (iID == 0)
                {
                    playerWeaponManager.weaponDamages[playerWeaponManager.weaponID] += addDamage;
                }

                // Add lifesteal
                if (iID == 1)
                {
                    playerWeaponManager.weaponLifesteal[playerWeaponManager.weaponID] += addLifesteal;
                }

                // Add health
                if (iID == 2)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().maxHealth += addHealth;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().currentHealth += addHealth;
                }

                // Add healthregeneration
                if (iID == 3)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().healthRegenRate += addHealthRegen;
                }
            }

            playerWeaponManager.hasWeapon = true;
        }
    }

    void ItemSpawn()
    {
        foreach (GameObject item in items)
        {
            if (roundManager.currentRound == 0 || chestID == 0)
            {
                if (items.IndexOf(item) == iID)
                {
                    if (!item.activeSelf)
                    {
                        item.SetActive(true);
                    }
                }
                else
                {
                    if (item.activeSelf) { item.SetActive(false); }
                }
            }
            
            if (roundManager.currentRound != 0 && chestID == 1 || roundManager.currentRound != 0 && chestID == 2)
            {
                if (item.activeSelf) { item.SetActive(false); }
            }
        }

        foreach (GameObject effect in effectsUpgrades)
        {
            if (roundManager.currentRound != 0 && chestID == 1 || roundManager.currentRound != 0 && chestID == 2)
            {
                if (effectsUpgrades.IndexOf(effect) == iID)
                {
                    if (!effect.activeSelf)
                    {
                        effect.SetActive(true);
                    }
                }
                else
                {
                    if (effect.activeSelf) { effect.SetActive(false); }
                }
            }

            if (roundManager.currentRound == 0 || chestID == 0)
            {
                if (effect.activeSelf) { effect.SetActive(false); }
            }
        }
    }

    public void SpawnRandomItem()
    {
        if (roundManager.currentRound == 0)
        {
            iID = Random.Range(0, items.Count);
        }

        if (roundManager.currentRound != 0)
        {
            #region Cofre izquierdo
            if (chestID == 0)
            {
                iID = Random.Range(0, items.Count);
            }
            #endregion

            #region Cofre central y derecho
            if (chestID == 1 || chestID == 2)
            {
                iID = Random.Range(0, effectsUpgrades.Count);
            }
            #endregion
        }
    }
}
