using UnityEngine;
public class EnemyModel : MonoBehaviour
{
    private EnemiesParam _enemiesParam;
    private float _currentHealth;
    private BoundsCheck _boundsCheck;

    public EnemiesParam enemiesParam => _enemiesParam;

    public EnemyModel(EnemiesParam param)
    {
        _enemiesParam = param;
        _currentHealth = _enemiesParam.health;
    }


    public Vector3 pos
    {
        get { return (this.transform.position); }
        set { this.transform.position = value; }
    }

    private void Awake()
    {
        _boundsCheck = GetComponent<BoundsCheck>();
    }

    private void Update()
    {
        Move();

        if (_boundsCheck != null && _boundsCheck.offDown)
        {
            Destroy(gameObject);
        }
    }

    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= _enemiesParam.speed * Time.deltaTime;
        pos = tempPos;
    }
}
