using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private float _shieldLevel = 4;
    private GameObject _lastTrigger = null;
     
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


    private void OnTriggerEnter(Collider other)
        {
            Transform rootTransform = other.gameObject.transform.root;
            GameObject gameObject = rootTransform.gameObject;

            if (gameObject == _lastTrigger)
            { return; }
            _lastTrigger = gameObject;

            if (gameObject.CompareTag("Enemy"))
            {
                _shieldLevel--;
                Destroy(gameObject);
                ShieldLevel = _shieldLevel;
            }
            else { Debug.Log("Triggered by non-Enemy: " + gameObject.name); }
        }
    
}
