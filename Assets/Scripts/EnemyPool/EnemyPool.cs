using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Object = UnityEngine.Object;

internal sealed class EnemyPool
{
    private readonly Dictionary<string, HashSet<Enemy>> _enemyPolling;
    private readonly int _capacityPool;
    private Transform _rootPool;

    public EnemyPool(int capacityPool)
    {
        _enemyPolling = new Dictionary<string, HashSet<Enemy>>();
        _capacityPool = capacityPool;
        if (!_rootPool)
        {
            _rootPool = new GameObject(PoolManager.POOL_AMMUNITION).transform;
        }
    }

    public Enemy GetEnemy(string type)
    {
        Enemy result;
        switch (type)
        {
            case "EnemyType0":
                result = GetShipEnemy(GetListEnemies(type));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, "");
        }
        return result;
    }

    private HashSet<Enemy> GetListEnemies(string type)
    {
        return _enemyPolling.ContainsKey(type) ? _enemyPolling[type] : _enemyPolling[type] = new HashSet<Enemy>();
    }

    private Enemy GetShipEnemy(HashSet<Enemy> enemies)
    {
        var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
        if (enemy == null)
        {
            var laser = Resources.Load<Enemy>("Enemy/EnemyType0");
            for (var i = 0; i < _capacityPool; i++)
            {
                var instantiate = Object.Instantiate(laser);
                ReturnToPool(instantiate.transform);
                enemies.Add(instantiate);
            }
            GetShipEnemy(enemies);
        }
        enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
        return enemy;
    }

    private void ReturnToPool(Transform transform)
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.gameObject.SetActive(false);
        transform.SetParent(_rootPool);
    }
}
