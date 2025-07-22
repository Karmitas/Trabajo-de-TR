using UnityEngine;
using UnityEngine.AI;

public class GoToPoint : MonoBehaviour
{
    
    [Header("Settings")]
    public NavMeshAgent agent;
    public Transform destination;

    [Space]
    public float stopingDistance = 1;

    [Header("Debug")]
    public bool isIdle;

    void Start()
    {
        if (agent == null)
        {  agent = GetComponent<NavMeshAgent>(); }

        agent.stoppingDistance = stopingDistance;

        if (destination == null)
        {
            destination = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
    }

    void Update()
    {
        agent.SetDestination(destination.transform.position);
    }

    private void LateUpdate()
    {
        if (agent.velocity.magnitude < 0.15f)
        {
            if (!isIdle) { isIdle = true; }
        } else
        {
            if (isIdle) { isIdle = false; }
        }
    }
}
