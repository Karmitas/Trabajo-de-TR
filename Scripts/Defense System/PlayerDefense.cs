using UnityEngine;

public class PlayerDefense : MonoBehaviour
{
    [Header("Swords-Type")]
    public EnemyAttack enemyAttack;
    public bool parry = true;

    [Header("Proyectiles")]
    public bool destroyItem = false;
    public GameObject parentObject;

    [Header("Blood Prefab")]
    public GameObject bloodPrefab;

    private void Start()
    {
        if (parentObject == null && destroyItem)
        {
            parentObject = this.gameObject;
        }
    }
    public void InteractItem(bool x)
    {
        if (x)
        {
            if (destroyItem)
            {
                Destroy(parentObject);
            }

            if (!destroyItem)
            {
                if (parry)
                {
                    enemyAttack.ForceStopAttack();
                }            
            }

            GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponCharge>().isCharged = false;
        }

        if (!x)
        {
            if (destroyItem)
            {
                Destroy(parentObject);
            }

            if (!destroyItem)
            {
                enemyAttack.ForceStopAttack();
                if (parry)
                {
                    enemyAttack.ForceStopAttack();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player Weapon"))
        {
            InteractItem(true);
            ParryVisual(other.transform);
        }
        if (other.CompareTag("Player Shield"))
        {             
            InteractItem(false);
            ParryVisual(other.transform);
        }
    }

    public void ParryVisual(Transform damagedPos)
    {
        bloodPrefab.transform.position = damagedPos.transform.position;
        bloodPrefab.transform.LookAt(gameObject.transform.position);
        Instantiate(bloodPrefab);
    }
}
