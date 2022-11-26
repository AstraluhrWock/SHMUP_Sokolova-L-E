using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TypesOfEnemy", menuName = "TypesOfEnemy", order = 51)]
public class EnemyData : ScriptableObject 
{
    [SerializeField] private List<EnemiesParam> _enemyFirstLevel;
    [SerializeField] private List<EnemiesParam> _enemySecondLevel;

    public List<EnemiesParam> EnemyFirstLevel => _enemyFirstLevel;
    public List<EnemiesParam> EnemySecondLevel => _enemySecondLevel;

}




