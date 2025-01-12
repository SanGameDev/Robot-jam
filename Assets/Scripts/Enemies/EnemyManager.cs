using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyData enemyData;

    private Transform player;
    private Animator animator;
    private EnemyMovement enemyMovement;
    private EnemyAttack enemyAttack;

    private int health;
    private bool canAttack = true;
    private float attackCooldown;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;   
        animator = GetComponent<Animator>();

        enemyMovement = GetComponent<EnemyMovement>();
        enemyAttack = GetComponent<EnemyAttack>();

        this.health = enemyData.health;
        this.attackCooldown = enemyData.attackCooldown;
    }
    private void Update() 
    {
        if(enemyMovement.InAttackRange(enemyData.attackRange, player))
        {
            enemyMovement.StopMovement();
            animator.SetBool("Moving", false);

            if(canAttack)
            {
                animator.SetBool("Attacking", true);
                enemyAttack.Attack(enemyData.damage, player, enemyData.attackCooldown);
            }
            else
                StartCooldown();
        }
        else
        {
            enemyMovement.MoveToAttackRange(enemyData.speed, player);
            animator.SetBool("Moving", true);
            animator.SetBool("Attacking", false);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Hand"))
        {
            health -= 1;
            if(health <= 0)
            {
                FindAnyObjectByType<GameManager>().AddScore(10);
                Destroy(gameObject);
            }
        }
    }

    public void StartCooldown()
    {
        attackCooldown -= Time.deltaTime;
        if(attackCooldown <= 0)
        {
            canAttack = true;
            attackCooldown = enemyData.attackCooldown;
        }
    }

    public void FinishedAttack()
    {
        canAttack = false;
        animator.SetBool("Attacking", false);
    }
}
