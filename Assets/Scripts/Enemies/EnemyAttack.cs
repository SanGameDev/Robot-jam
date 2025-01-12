using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public void Attack(float damage, Transform player, float attackCooldown)
    {
        //player.GetComponent<PlayerHealth>().TakeDamage(damage);
        Debug.Log("Attacking player for " + damage + " damage");
    }
}
