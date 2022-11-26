using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    
    private GameObject _lastTrigger = null;
     



   /* private void OnTriggerEnter(Collider other)
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
        }*/
    
}
