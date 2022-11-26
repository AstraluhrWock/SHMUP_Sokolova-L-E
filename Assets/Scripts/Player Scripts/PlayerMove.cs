using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 30;
    [SerializeField] private float _rollAngle = -45;
    [SerializeField] private float _pitchAngle = 30;

    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";

    public void Move()
    {
        float xAxis = Input.GetAxis(_horizontal);
        float yAxis = Input.GetAxis(_vertical);

        Vector3 pos = transform.position;
        pos.x += xAxis * _speed * Time.deltaTime;
        pos.y += yAxis * _speed * Time.deltaTime;
        transform.position = pos;

        transform.rotation = Quaternion.Euler(yAxis * _pitchAngle, xAxis * _rollAngle, 0);
    }
}
