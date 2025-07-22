using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class PlayerWeaponManager : MonoBehaviour
{

    [Header("Parameters")]
    public int weaponValue = 0;
    public bool hasWeapon = false;

    [Space] 
    [TextArea(2, 1000)]
    public string weaponValuesReference;

    [Space]
    public List<float> weaponDamages = new List<float>();
    public List<float> weaponLifesteal = new List<float>();

    [Header("Set Objects")]
    public GameObject controllerVisual;
    public GameObject nearFarInteraction;
    [Space]
    public List<GameObject> weapons = new List<GameObject>();

    [Header("In Game")]
    public float damage;
    public float lifesteal;

    [HideInInspector]
    public int weaponID;

    void Start()
    {
        controllerVisual.SetActive(true);
        nearFarInteraction.SetActive(true);

        foreach (GameObject weapon in weapons)
        {
            if (weapon.activeSelf) { weapon.SetActive(false); }
        }
    }

    void Update()
    {
        WeaponSetActive(weaponValue);
        DamageSetValue(weaponValue);
        LifestealSetValue(weaponValue);
    }

    void WeaponSetActive(int x)
    {
        if (!hasWeapon) { if (!controllerVisual.activeSelf) { controllerVisual.SetActive(true); nearFarInteraction.SetActive(true); } } else { if (controllerVisual.activeSelf) {controllerVisual.SetActive(false); nearFarInteraction.SetActive(false); } }
        
        if (hasWeapon)
        {
            foreach (GameObject weapon in weapons)
            {
                if (weapons.IndexOf(weapon) == x)
                {
                    if (!weapon.activeSelf)
                    {
                        weapon.SetActive(true);
                        weaponID = weapons.IndexOf(weapon);
                    }
                }
                else
                {
                    if (weapon.activeSelf) { weapon.SetActive(false); }
                }
            }
        }
    }

    void DamageSetValue(int y)
    {
        if (!hasWeapon) { damage = 0; }
        damage = weaponDamages[y];
    }

    void LifestealSetValue(int y)
    {
        if (!hasWeapon) { lifesteal = 0; }
        lifesteal = weaponLifesteal[y];
    }
}
