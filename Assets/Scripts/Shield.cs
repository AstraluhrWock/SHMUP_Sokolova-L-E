using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float rotationPerSecond = 0.1f;
    public int levelShown = 0;

    private Material _material;

    private void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        int currentLevel = Mathf.FloorToInt(Ship.ship.shieldLevel);
        if (levelShown != currentLevel)
        {
            levelShown = currentLevel;
            _material.mainTextureOffset = new Vector2(0.2f * levelShown, 0);
        }
        float rZ = -(rotationPerSecond * Time.time * 360) % 360f;
        transform.rotation = Quaternion.Euler(0, 0, rZ);
    }
}
