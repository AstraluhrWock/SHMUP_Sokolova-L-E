using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public float fireRate = 0.3f;
    public float health = 10;
    public int score = 100;

    private BoundsCheck _boundsCheck;

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
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject bullet = collision.gameObject;
        if (bullet.tag == "ProjectileShip")
        {
            Destroy(bullet);
            Destroy(gameObject);
        }
        else {
            print("Enemy hit by non-ProjectileShip: " + bullet.name);
        }
    }
}
