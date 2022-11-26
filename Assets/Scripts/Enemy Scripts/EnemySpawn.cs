using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private Dictionary<string, Func<int, EnemyModel>> enemyFactory;

    public void Init(EnemyData enemyData)
    {
        enemyFactory = new Dictionary<string, Func<int, EnemyModel>>()
        {
            { "Enemy Type 1", (level) => new EnemyModel(enemyData.EnemyFirstLevel[level]) },
            { "Enemy Type 2", (level) => new EnemyModel(enemyData.EnemySecondLevel[level]) },
        };
    }

    public EnemyModel CreateEnemyModel(string nameOfEnemy, int level)
    {
        return enemyFactory[nameOfEnemy](level);
    }
}
