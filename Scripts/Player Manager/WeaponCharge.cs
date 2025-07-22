using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class WeaponCharge : MonoBehaviour
{

    [Header("Parameters")]
    public PlayerWeaponManager playerWeaponManager;

    [Space]
    public bool isCharged;

    [Header("Weapon Visuals")]
    public List<GameObject> weaponVisuals = new List<GameObject>();

    [Header("Weapon Hitboxes")]
    public List<GameObject> weaponHitboxes = new List<GameObject>();

    [Header("Weapon Charge Positions")]
    public List<GameObject> weaponChargePositions = new List<GameObject>();

    void Update()
    {
        if (playerWeaponManager.hasWeapon)
        {
            foreach (GameObject weaponChargePosition in weaponChargePositions)
            {
                if (weaponChargePositions.IndexOf(weaponChargePosition) == playerWeaponManager.weaponValue)
                {
                    if (!isCharged)
                    {
                        if (!weaponChargePosition.activeSelf)
                        {
                            weaponChargePosition.SetActive(true);
                        }
                    }
                    if (isCharged)
                    {
                        if (weaponChargePosition.activeSelf)
                        {
                            weaponChargePosition.SetActive(false);
                        }
                    }
                }
                else
                {
                    if (weaponChargePosition.activeSelf)
                    {
                        weaponChargePosition.SetActive(false);
                    }
                }
            }

            foreach (GameObject weaponVisual in weaponVisuals)
            {
                if (weaponVisuals.IndexOf(weaponVisual) == playerWeaponManager.weaponValue)
                {
                    if (!isCharged)
                    {
                        if (weaponVisual.activeSelf)
                        {
                            weaponVisual.SetActive(false);
                        }
                    }

                    if (isCharged)
                    {
                        if (!weaponVisual.activeSelf)
                        {
                            weaponVisual.SetActive(true);
                        }
                    }
                }
                else
                {
                    if (weaponVisual.activeSelf)
                    {
                        weaponVisual.SetActive(false);
                    }
                }
            }

            foreach (GameObject weaponHitbox in weaponHitboxes)
            {
                if (weaponHitboxes.IndexOf(weaponHitbox) == playerWeaponManager.weaponValue)
                {
                    if (!isCharged)
                    {
                        if (weaponHitbox.activeSelf)
                        {
                            weaponHitbox.SetActive(false);
                        }
                    }

                    if (isCharged)
                    {
                        if (!weaponHitbox.activeSelf)
                        {
                            weaponHitbox.SetActive(true);
                        }
                    }
                }
                else
                {
                    if (weaponHitbox.activeSelf)
                    {
                        weaponHitbox.SetActive(false);
                    }
                }
            }
        }
    }

    public void Charge()
    {
        if (playerWeaponManager.hasWeapon)
        {
            isCharged = true;
        }
    }
}
