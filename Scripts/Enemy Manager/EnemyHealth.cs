using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class EnemyHealth : MonoBehaviour
{
    [Header("Parameters")]
    public float maxHp = 100;
    public float damageCooldown = 0.5f;

    [Space]
    public bool isBoss = false; // If true, the enemy is a boss

    [Header("Set")]
    public PlayerWeaponManager damage;
    public GameObject characterParent;
    [Space]
    public GameObject bloodPrefab;

    [Header("In Game")]
    public float hp = 100;
    public float dc;

    [Header("Visual Feedback Red Color")]
    public List<GameObject> materialParts = new List<GameObject>();

    [Space]
    public float timeToChangeColor = 0.2f;
    private bool vfrc;
    private float ttcc;

    [Header("Skybox")]
    public Material skyboxMaterial;
    public Material bossSkyboxMaterial;

    private bool x;

    private Animator bossPilar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        damage = GameObject.FindGameObjectWithTag("PlayerDamage").GetComponent<PlayerWeaponManager>();

        dc = damageCooldown;
        hp = maxHp;
        
        ttcc = timeToChangeColor;

        if (isBoss)
        {
            bossPilar = GameObject.FindGameObjectWithTag("BossPilar").GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (damage == null) { damage = GameObject.FindGameObjectWithTag("PlayerDamage").GetComponent<PlayerWeaponManager>(); }

        if (dc  > 0) { dc -= Time.deltaTime; }

        if (hp <= 0) { Death(); }

        if (vfrc)
        {
            ttcc -= Time.deltaTime;
            if (ttcc <= 0)
            {
                foreach (GameObject part in materialParts)
                {
                    if (part != null)
                    {
                        part.GetComponent<Renderer>().material.color = Color.white;
                    }
                }
                vfrc = false;
                ttcc = timeToChangeColor;
            }
        }

        if (!x && isBoss)
        {
            x = true;
            StartBossFight();
        }
    }

    public void Damaged(Transform damagedPos, float multiplier)
    {
        if (dc <= 0)
        {
            hp -= (damage.damage * multiplier);
            dc = damageCooldown;
            GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponCharge>().isCharged = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().currentHealth += damage.lifesteal;
            DamagedVisual(damagedPos);
        }
    }

    public void DamagedVisual(Transform damagedPos)
    {
        bloodPrefab.transform.position = damagedPos.transform.position;
        bloodPrefab.transform.LookAt(gameObject.transform.position);
        ChangeColorRedFeedBack();
        Instantiate(bloodPrefab);
    }

    public void Death()
    {
        GameObject.FindGameObjectWithTag("EnemySpawnerSystem").GetComponent<RoundManager>().EnemyDied();
        if (isBoss)
        {
            EndBossFight();
        }
        Destroy(characterParent);
    }

    public void ChangeColorRedFeedBack()
    {
        foreach (GameObject part in materialParts)
        {
            if (part != null)
            {
                part.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        vfrc = true;
    }

    void StartBossFight()
    {
        RenderSettings.skybox = bossSkyboxMaterial;
        bossPilar.SetTrigger("start");
    }

    void EndBossFight()
    {
        RenderSettings.skybox = skyboxMaterial;
        bossPilar.SetTrigger("end");
    }
}
