using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public int health;
    public float speed;
    public float damage;
    public float attackRange;
    public float attackCooldown;
}
