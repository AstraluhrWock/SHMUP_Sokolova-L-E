using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ShipWeapon : MonoBehaviour
{
    private BoundsCheck _boundsCheck;
    [SerializeField] public GameObject _projectilePrefab;
    private GameObject _Projectile;
    private Rigidbody _rigidbody;
    public float projectileSpeed = 40;


    private void Awake()
    {
        _boundsCheck = GetComponent<BoundsCheck>();

    }

    public void FireOn()
    {
        GameObject _Projectile = Instantiate<GameObject>(_projectilePrefab);
        _Projectile.transform.position = transform.position;
        Rigidbody _rigidbody = _Projectile.GetComponent<Rigidbody>();
        _rigidbody.velocity = Vector3.up * projectileSpeed;
      
    }
}
