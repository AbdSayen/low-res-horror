using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float visibilityDistance;

    [Space(15)]
    [Header("Patrol")]
    [SerializeField] private Transform[] patrolPositions;
    [SerializeField] private Transform TATGET___;

    private Transform player;
    private NavMeshAgent agent;
    private Animator animator;

    // State
    private bool isSeeingTarget = false;
    private bool hasGoal = false;

    private const string IS_RUNNING = "IS_RUNNING";
    private const string IS_MOVE = "IS_MOVE";

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Follow(player);
        Patrol(patrolPositions);
    }

    private void Patrol(Transform[] patrolPositions)
    {
        if (!hasGoal && !isSeeingTarget && patrolPositions.Length > 0)
        {
            int goalId = Random.Range(0, patrolPositions.Length);
            agent.SetDestination(patrolPositions[goalId].position);
            animator.SetBool(IS_MOVE, true);
            agent.speed = walkSpeed;
            hasGoal = true;
        }

        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            animator.SetBool(IS_MOVE, false);
            hasGoal = false;
        }
    }

    private void Follow(Transform target)
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, target.position);
        isSeeingTarget = distance <= visibilityDistance;

        if (isSeeingTarget)
        {
            agent.SetDestination(target.position);
            animator.SetBool(IS_RUNNING, true);
            agent.speed = runSpeed;
        }
        else
        {
            animator.SetBool(IS_RUNNING, false);
        }
    }
}