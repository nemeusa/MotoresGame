using System.Collections.Generic;
using UnityEngine;
using static EnemyStats;

public class EnemyManager : MonoBehaviour
{
    public Dictionary<EnemyType, EnemyStats> enemies = new Dictionary<EnemyType, EnemyStats>();

    void Start()
    {
        //enemigos
        enemies.Add(EnemyType.Bee, new EnemyStats(10, 5));    
        enemies.Add(EnemyType.Mole, new EnemyStats(30, 10));   
        enemies.Add(EnemyType.Spikes, new EnemyStats(1, 10));  

        PrintStats(EnemyType.Bee);
        PrintStats(EnemyType.Mole);
        PrintStats(EnemyType.Spikes);
    }
    public EnemyStats GetEnemyStats(EnemyType enemyType)
    {
        if (enemies.ContainsKey(enemyType))
        {
            return enemies[enemyType];
        }
        else
        {
            Debug.LogError("Enemigo no encontrado: " + enemyType);
            return null;
        }
    }
        void PrintStats(EnemyType enemyType)
    {
        if (enemies.ContainsKey(enemyType))
        {
            EnemyStats stats = enemies[enemyType];
            Debug.Log($"{enemyType}: Health = {stats.health}, Damage = {stats.attack}");
        }
    }
}