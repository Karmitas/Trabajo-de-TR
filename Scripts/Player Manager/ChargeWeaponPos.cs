using UnityEngine;

public class ChargeWeaponPos : MonoBehaviour
{

    [Header("Parameters")]
    public WeaponCharge weaponCharge;

    void Start()
    {
        weaponCharge = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponCharge>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RightHandInteractuable"))
        {
            weaponCharge.Charge();
        }
    }
}
