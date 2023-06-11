using UnityEngine;
using BehaviorTree;

public class TaskPatrol : Node
{
    private Transform transform;
    private Animator animator;
    private Transform[] waypoints;

    private int currentWaypointIndex = 0;

    private float waitTime = 1f; // in seconds
    private float waitCounter = 0f;
    private bool isWaiting = true;

    public TaskPatrol(Transform transform, Transform[] waypoints)
    {
        this.transform = transform;
        animator = transform.GetComponent<Animator>();
        this.waypoints = waypoints;
    }

    public override NodeState Evaluate()
    {
        if (isWaiting)
        {
            waitCounter += Time.deltaTime;
            if (waitCounter >= waitTime)
            {
                isWaiting = false;
                animator.SetBool("IsWalking", true);
            }
        }
        else
        {
            Transform wp = waypoints[currentWaypointIndex];
            
            // Preserve the original character Y position.
            Vector3 targetPos = wp.position;
            targetPos.y = transform.position.y;

            if (Vector3.Distance(transform.position, targetPos) < 0.01f)
            {
                // Reset counter and randomize waiting time.
                waitTime = Random.Range(3f, 6f);
                waitCounter = 0f;
                isWaiting = true;

                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                animator.SetBool("IsWalking", false);
            }
            else
            {
                // Handle movement and rotation.
                transform.position = Vector3.MoveTowards(transform.position, targetPos, SlayerBT.walkSpeed * Time.deltaTime);
                transform.LookAt(targetPos);
            }
        }

        state = NodeState.RUNNING;
        return state;
    }

}