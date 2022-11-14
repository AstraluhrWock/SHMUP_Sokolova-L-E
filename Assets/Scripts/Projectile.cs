using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private BoundsCheck boundsCheck;

    private void Awake()
    {
        boundsCheck = GetComponent<BoundsCheck>();
    }

    void Update()
    {
        if (boundsCheck.offUp)
        {
            Destroy(gameObject);
        }
    }
}
