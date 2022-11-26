using UnityEngine;

internal abstract class Enemy : MonoBehaviour
{
    #region Методичка
    //public static IEnemyFactory Factory;
    private Transform _rootPool;
    private Health _health;

    public Health Health
    {
        get
        {
            if (_health.currentHealth <= 0.0f)
            {
                ReturnToPool();
            }
            return _health;
        }

        protected set => _health = value; 
    }

    public Transform RootPool 
    {
        get
        {
            if (_rootPool == null)
            {
                var find = GameObject.Find(PoolManager.POOL_AMMUNITION);
                _rootPool = find == null ? null : find.transform;
            }
            return _rootPool;
        }  
    }
    #endregion

    public float enemySpawnPerSecond = 0.5f;
    public float enemyDefaultPadding = 1.5f;

    private BoundsCheck _boundsCheck;

    private void Awake()
    {
        _boundsCheck = GetComponent<BoundsCheck>();
    }

    public static Enemy CreateEnemy(Health hp)
    {
        var enemy0 = Instantiate(Resources.Load<Enemy>("Enemy/EnemyType0"));
        enemy0.Health = hp;
        return enemy0;
    }

    public void SetPositionEnemy()
    {
        float enemyPadding = enemyDefaultPadding;
        if (gameObject.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(gameObject.GetComponent<BoundsCheck>().Radius);
        }

        Vector3 pos = Vector3.zero;
        float xMin = _boundsCheck.camWidth + enemyPadding;
        float xMax = _boundsCheck.camWidth - enemyPadding;
        pos.x = Random.Range(xMin, xMax);
        pos.y = _boundsCheck.camHeight + enemyPadding;
        gameObject.transform.position = pos;
        Invoke(nameof(SetPositionEnemy), 1f / enemySpawnPerSecond);
    }

    #region Методичка
    protected void ReturnToPool()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        gameObject.SetActive(false);
        transform.SetParent(RootPool);

        if(!RootPool)
        {
            Destroy(gameObject);
        }
    }

    public static Enemy CreateShipEnemy(Health hp)
    {
        var enemy = Instantiate(Resources.Load<Enemy>("Enemy/EnemyType0"));
        enemy.Health = hp;
        return enemy;
    }

    public void ActiveEnemy(Vector3 position, Quaternion rotation)
    {
        transform.localPosition = position;
        transform.localRotation = rotation;
        gameObject.SetActive(true);
        transform.SetParent(null);
    }
    #endregion
}
