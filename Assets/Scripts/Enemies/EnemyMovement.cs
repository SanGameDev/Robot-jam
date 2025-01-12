using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public void MoveToAttackRange(float speed, Transform player)
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.isStopped = false;
        agent.speed = speed;
        agent.SetDestination(player.position);
    }

    public void StopMovement()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;
        agent.ResetPath();
    }

    public bool InAttackRange(float attackRange, Transform player)
    {
        return Vector3.Distance(transform.position, player.position) <= attackRange;
    }
}
