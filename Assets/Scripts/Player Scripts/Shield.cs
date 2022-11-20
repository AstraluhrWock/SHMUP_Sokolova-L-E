using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private float _rotationPerSecond = 0.1f;
    private int _levelShown = 0;
    private DamageController damageController;

    private Material _material;

    private void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        /*int currentLevel = Mathf.FloorToInt(damageController.ShieldLevel);
        if (_levelShown != currentLevel)
        {
            _levelShown = currentLevel;
            _material.mainTextureOffset = new Vector2(0.2f * _levelShown, 0);
        }
        float rZ = -(_rotationPerSecond * Time.time * 360) % 360f;
        transform.rotation = Quaternion.Euler(0, 0, rZ);*/
    }
}
