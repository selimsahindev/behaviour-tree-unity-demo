using UnityEngine;

using BehaviorTree;

public class TaskGoToTarget : Node
{
    private Transform transform;

    public TaskGoToTarget(Transform transform)
    {
        this.transform = transform;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if (Vector3.Distance(transform.position, target.position) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, SlayerBT.runSpeed * Time.deltaTime);
            transform.LookAt(target.position);
        }

        state = NodeState.RUNNING;
        return state;
    }

}