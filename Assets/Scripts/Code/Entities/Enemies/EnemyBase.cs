using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private Animator enemyAnim;

    [SerializeField] private float _speed;
    private float _movementInitialSide;
    [SerializeField] private float _timeToSwicthSide;

    private PlayerHealthBehavior playerHealthCTL;

    private void Start()
    {
        enemyAnim = GetComponent<Animator>();
        playerHealthCTL = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthBehavior>();
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            StartCoroutine("AttackBehavior");
        }
    }

    private IEnumerator AttackBehavior()
    {
        enemyAnim.SetTrigger("Attack");
        playerHealthCTL.OnPlayerDamaged.RaiseEvent(this, 2);
        yield return new WaitForSeconds(0.25f);
        _speed *= -1f;
        _timeToSwicthSide = 5f - _timeToSwicthSide;
    }

    public void OnDamageTaken()
    {
        _speed = 0f;
        enemyAnim.SetTrigger("IsDead");
        Destroy(gameObject, 1.25f);
    }
}