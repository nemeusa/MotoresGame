using UnityEngine;
using static EnemyStats;

public class EnemyController : MonoBehaviour
{
    public EnemyType enemyType; 
    public int health;
    public int damage;

    void Start()
    {
        AssignStats();
    }

    void AssignStats()
    {
        EnemyManager enemyManager = FindObjectOfType<EnemyManager>();

        if (enemyManager != null)
        {
            EnemyStats stats = enemyManager.GetEnemyStats(enemyType);
            health = stats.health;
            damage = stats.attack;
        }
    }
}