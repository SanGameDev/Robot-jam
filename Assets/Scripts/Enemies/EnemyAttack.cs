using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public void Attack(float damage, Transform player)
    {
        player.GetComponent<PlayerHealth>().TakeDamage(damage);
        GetComponent<EnemyManager>().canAttack = false;
    }
}
