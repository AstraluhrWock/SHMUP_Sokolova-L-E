using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    static public Ship ship;
    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;
    public float gameRestartDelay = 2f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 40;


    [SerializeField] private float _shieldLevel = 1;
    private GameObject lastTrigger = null;

    public float shieldLevel
    {
        get { return _shieldLevel; }
        set
        { 
            _shieldLevel = Mathf.Min(value, 4);
            if (value < 0)
            {
                Destroy(this.gameObject);
                Main.main.DelayedRestart(gameRestartDelay);
            }
        }
    }

    void Awake()
    {
        if (ship == null)
            ship = this;
        else {
            Debug.LogError("Hero.Awake() - Attemted to assign second Ship.ship");
        }
    }

    void Update()
    {
        MoveShip();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            TempFire();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform rootTransform = other.gameObject.transform.root;
        GameObject gameObject = rootTransform.gameObject;

        if (gameObject == lastTrigger)
        { return; }
        lastTrigger = gameObject;

        if (gameObject.tag == "Enemy")
        {
            _shieldLevel--;
            Destroy(gameObject);
        }
        else { print("Triggered by non-Enemy: " + gameObject.name);  }

    }

    void MoveShip()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;

        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);
    }

    void TempFire()
    {
        GameObject bullet = Instantiate<GameObject>(projectilePrefab);
        bullet.transform.position = transform.position;
        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.up * projectileSpeed;
    }
}
