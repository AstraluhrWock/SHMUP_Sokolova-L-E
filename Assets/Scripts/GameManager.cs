using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;
    private EnemySpawn _enemySpawn;
    public GameObject[] prefabEnemies;

    private void Start()
    {
        _enemySpawn = new EnemySpawn();
        _enemySpawn.Init(_enemyData);
        _enemySpawn.CreateEnemyModel("Type ship 1", 2);
    }
}
