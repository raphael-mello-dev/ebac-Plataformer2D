using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _movementInitialSide;

    [SerializeField] private float _timeToSwicthSide;

    private void Start()
    {
        _movementInitialSide = Random.Range(-1f, 1f);
        
        if (_movementInitialSide < 0)
            _speed *= -1f;
    }

    private void Update()
    {
        OnRotate();
        OnMovement();
    }

    private void OnMovement()
    {
        transform.position += new Vector3(_speed, 0, 0) * Time.deltaTime;
        _timeToSwicthSide -= Time.deltaTime;

        if (_timeToSwicthSide <= 0)
        {
            _speed *= -1f;
            _timeToSwicthSide = 5f;
        }
    }

    private void OnRotate()
    {
        if (_speed < 0)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else if (_speed > 0)
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }
}