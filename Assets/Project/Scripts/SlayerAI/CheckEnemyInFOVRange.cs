using UnityEngine;

using BehaviorTree;

public class CheckEnemyInFOVRange : Node
{
    private static int enemyLayerMask = 1 << 6; // Enemy

    private Transform transform;
    private Animator animator;

    public CheckEnemyInFOVRange(Transform transform)
    {
        this.transform = transform;
        animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, SlayerBT.fovRange, enemyLayerMask);

            if (colliders.Length > 0)
            {
                parent.parent.SetData("target", colliders[0].transform);
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsRunning", true);
                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.FAILURE;
            return state;
        }

        state = NodeState.SUCCESS;
        return state;
    }

}