using UnityEngine;

public class EnemyAnim : MonoBehaviour
{

    [Header("Parameters")]
    public Animator anim;

    [Header("Movement")]
    public GoToPoint movementChecker;
    public bool isIdle;

    void LateUpdate()
    {
        VariableSet();

        if (movementChecker != null) { anim.SetBool("isIdle", isIdle); }
    }

    void VariableSet()
    {
        if (movementChecker == null)
        {
            movementChecker = GetComponentInParent<GoToPoint>();
        }
        isIdle = movementChecker.isIdle;
    }
}
