using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyData enemyData;

    private Transform player;
    private Animator animator;
    private EnemyMovement enemyMovement;
    private EnemyAttack enemyAttack;
    private GameManager gameManager;

    private int health;
    [HideInInspector] public bool canAttack = true;
    private float attackCooldown;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;   
        animator = GetComponent<Animator>();

        enemyMovement = GetComponent<EnemyMovement>();
        enemyAttack = GetComponent<EnemyAttack>();

        gameManager = FindAnyObjectByType<GameManager>();

        this.health = enemyData.health;
        this.attackCooldown = enemyData.attackCooldown;
    }

    private void Update() 
    {
        if(!gameManager.isGameOver)
        {
            if(enemyMovement.InAttackRange(enemyData.attackRange, player))
            {
                enemyMovement.StopMovement();
                animator.SetBool("Moving", false);

                if(canAttack)
                {
                    animator.SetBool("Attacking", true);
                    enemyAttack.Attack(enemyData.damage, player);
                }
                else
                {
                    StartCooldown();
                }
            }
            else
            {
                enemyMovement.MoveToAttackRange(enemyData.speed, player);
                animator.SetBool("Moving", true);
                animator.SetBool("Attacking", false);
            }
        }
        else
        {
            animator.SetTrigger("GameOv");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Hand"))
        {
            health -= 1;
            if(health <= 0)
            {
                FindAnyObjectByType<GameManager>().AddScore(10);
                animator.SetTrigger("Dead");
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
        animator.SetBool("Attacking", false);
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
