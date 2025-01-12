using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyData enemyData;

    private Transform player;
    private EnemyMovement enemyMovement;
    private EnemyAttack enemyAttack;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;   

        enemyMovement = GetComponent<EnemyMovement>();
        enemyAttack = GetComponent<EnemyAttack>();
    }
    private void Update() 
    {
        if(enemyMovement.InAttackRange(enemyData.attackRange, player))
        {
            enemyMovement.StopMovement();

            enemyAttack.StartAttack(enemyData.damage, player, enemyData.attackCooldown);
        }
        else
        {
            enemyMovement.MoveToAttackRange(enemyData.speed, player);
        }
    }
}
