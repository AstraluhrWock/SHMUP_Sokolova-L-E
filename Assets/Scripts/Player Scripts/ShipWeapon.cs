using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapon : MonoBehaviour
{
    private BoundsCheck _boundsCheck;
    [SerializeField] private GameObject _projectilePrefab;
    private GameObject _bullet;
    private Rigidbody _rigidbody;
    public float projectileSpeed = 40;

    private void Awake()
    {
        _boundsCheck = GetComponent<BoundsCheck>();
        _bullet = Instantiate<GameObject>(_projectilePrefab);
        _rigidbody = _bullet.GetComponent<Rigidbody>();
    }

   /* void Update()
    {
        if (_boundsCheck.offUp)
        {
            Destroy(gameObject);
        }
    }*/

    public void TempFire()
    {
        _bullet.transform.position = transform.position;
        _rigidbody.velocity = Vector3.up * projectileSpeed;
    }
}
