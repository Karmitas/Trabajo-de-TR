using UnityEngine;

public class RotateAroundPlayer : MonoBehaviour
{
    [Header("Set")]
    public EnemyAttack enemyAttack;
    [Space]
    public GoToPoint gotopoint;
    [Space]
    public GameObject body;

    [Header("Debug")]
    public GameObject[] pointsToGo;
    [Space]
    public GameObject target;

    private bool x;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        pointsToGo = GameObject.FindGameObjectsWithTag("NearPoint");
    }
    void Update()
    {
        if (enemyAttack.enemyAnim.isIdle)
        {
            if (!x)
            {
                x = true;
                gotopoint.destination = pointsToGo[Random.Range(0, pointsToGo.Length)].transform;
                enemyAttack.enemyAnim.anim.SetBool("walk", true);
            }
        }
        if (!enemyAttack.enemyAnim.isIdle)
        {
            if (x)
            {
                x = false;
                gotopoint.destination = target.transform;
                enemyAttack.enemyAnim.anim.SetBool("walk", false);
            }
        }
    }
}
