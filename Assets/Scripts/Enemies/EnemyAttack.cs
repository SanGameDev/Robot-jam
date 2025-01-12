using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public void StartAttack(float damage, Transform player, float attackCooldown)
    {
        StartCoroutine(AttackCooldown(attackCooldown));
        player.GetComponent<PlayerHealth>().TakeDamage(damage);
    }

    public IEnumerator AttackCooldown(float attackCooldown)
    {
        yield return new WaitForSeconds(attackCooldown);
    }
}
