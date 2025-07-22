using UnityEngine;

public class MovingAttack : MonoBehaviour
{

    [Header("Parameters")]
    public GameObject damageHitbox;
    public float speed = 5f;
    public float attackDuration = 1f;

    [Space]
    public Animator anim;
    public GameObject parent;

    private float attackTimer;

    void Start()
    {
        attackTimer = attackDuration;
    }
    void Update()
    {
        if (damageHitbox.activeSelf)
        {
            parent.transform.Translate(Vector3.forward * speed * Time.deltaTime);

            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0)
            {
                damageHitbox.SetActive(false);
                attackTimer = attackDuration;
                anim.SetTrigger("EndAttack");
            }
        }
    }
}
