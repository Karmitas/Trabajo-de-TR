using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class EnemyAttack : MonoBehaviour
{

    [Header("Parameters")]
    public float attackCooldown = 5.0f; // Time between attacks

    private float ac; // Attack cooldown timer

    [Header("Attack Pattern")]
    public int extendedAttackCount = 1; // Number of attacks in the pattern
    public float attackTimeBetweenCombo = 0.25f;

    private float atbc; // Timer for time between attacks in the combo

    [Space]
    public int attackCount = 0; // Current attack count

    [Header("Set")]
    public EnemyAnim enemyAnim; // Reference to the enemy animation script

    private bool x;
    private bool y;

    [Header("Extra Scripts")]
    public List<GameObject> extraParts = new List<GameObject>();

    void Start()
    {
        ac = attackCooldown;
        atbc = attackTimeBetweenCombo;
    }
    void Update()
    {
        if (enemyAnim.isIdle && !x)
        {
            ac -= Time.deltaTime;

            if (ac <= 0)
            {
                y = false;
                x = true;
            }
        }
        else
        {
            ac = attackCooldown;
        }

        if (x)
        {
            if (!y)
            {
                attackCount++;
                enemyAnim.anim.SetInteger("AttackCount", attackCount);
                enemyAnim.anim.SetTrigger("Attack");
                
                y = true;
            }

            if (y)
            {
                atbc -= Time.deltaTime;
                if (atbc <= 0)
                {
                    y = false; x = false;
                    atbc = attackTimeBetweenCombo;
                }
            }
        }

        if (attackCount >= extendedAttackCount && !x)
        {
            x = false;
            y = false;
            attackCount = 0;
            enemyAnim.anim.SetInteger("AttackCount", attackCount);
            atbc = attackTimeBetweenCombo; // Reset the time between combo attacks
            ac = attackCooldown; // Reset cooldown after completing the attack pattern
        }
    }

    public void ForceStopAttack()
    {
        x = false;
        y = false;
        attackCount = 0;
        enemyAnim.anim.SetInteger("AttackCount", attackCount);
        atbc = attackTimeBetweenCombo; // Reset the time between combo attacks
        ac = attackCooldown; // Reset cooldown after completing the attack pattern
        enemyAnim.anim.SetTrigger("Parry");

        foreach (GameObject part in extraParts)
        {
            if (part.activeSelf)
            {
                part.SetActive(false);
            }
        }
    }
}
