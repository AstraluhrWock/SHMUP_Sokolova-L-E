using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public static Ship ship;

    private PlayerMove _playerMove;
    //private DamageController _damageController;
    //private ReloadGame _reloadGame;
    private ShipWeapon _shipWeapon;


    void Awake()
    {
        _playerMove = GetComponent<PlayerMove>();
        //_damageController = GetComponent<DamageController>();

        if (ship == null) // ship является переменной, а не gameObject
            ship = this;
        else
        {
            Debug.LogError("Hero.Awake() - Attemted to assign second Ship.ship");
        }
    }

    void Update()
    {
        _playerMove.Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _shipWeapon.TempFire();
        }
    }

}




