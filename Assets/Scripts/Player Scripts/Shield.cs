using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private float _rotationPerSecond = 0.1f;
    private int _levelShown = 0;
    //private DamageController damageController;
    [SerializeField] private float _shieldLevel = 4;

    private Material _material;

    public float ShieldLevel
    {
        get { return _shieldLevel; }
        set
        {
            _shieldLevel = Mathf.Min(value, 4);
            if (_shieldLevel < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        int currentLevel = Mathf.FloorToInt(ShieldLevel);
        if (_levelShown != currentLevel)
        {
            _levelShown = currentLevel;
            _material.mainTextureOffset = new Vector2(0.2f * _levelShown, 0);
        }
        float rZ = -(_rotationPerSecond * Time.time * 360) % 360f;
        transform.rotation = Quaternion.Euler(0, 0, rZ);
    }
}
