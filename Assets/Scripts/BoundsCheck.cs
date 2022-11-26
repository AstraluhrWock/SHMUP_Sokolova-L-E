using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    [SerializeField] private float _radius = 1f;
    [SerializeField] private bool _keepOnScreen = true;
    [SerializeField] private bool _isOnScreen = true;

    public float camWidth;
    public float camHeight;
    public bool offRight, offLeft, offUp, offDown = false;

    public float Radius
    {
        get { return _radius; }
        set { _radius = value; }
    }

    private void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        _isOnScreen = true;
        offRight = offLeft = offUp = offDown = false;

        if (pos.x > camWidth - _radius)
        {
            pos.x = camWidth - _radius;
            _isOnScreen = false;
            offRight = true;
        }

        if (pos.x < -camWidth + _radius)
        {
            pos.x = -camWidth + _radius;
            _isOnScreen = false;
            offLeft = true;
        }

        if (pos.y > camHeight - _radius)
        {
            pos.y = camHeight - _radius;
            _isOnScreen = false;
            offUp = true;
        }

        if (pos.y < -camHeight + _radius)
        {
            pos.y = -camHeight + _radius;
            _isOnScreen = false;
            offDown = true;
        }

        _isOnScreen = !(offRight || offLeft || offUp || offDown);
        if (_keepOnScreen && !_isOnScreen)
        {
            transform.position = pos;
            _isOnScreen = true;
            offRight = offLeft = offUp = offDown = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 boundSize = new Vector3(camWidth * 2, camHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
}
