using UnityEngine;

public class Laser : MonoBehaviour
{
    private Animator objAnim;

    private PlayerRotationBehavior playerDir;
    private float lastDir;

    private GameObject shotPoint;

    public bool CollidedWithEnemy { private set; get; }
    [SerializeField] private LayerMask enemiesLayer;

    private void Awake()
    {
        objAnim = GetComponent<Animator>();
        playerDir = FindObjectOfType<PlayerRotationBehavior>().GetComponent<PlayerRotationBehavior>();
    }

    private void OnEnable()
    {
        shotPoint = GameObject.FindGameObjectWithTag("Shot_Point");
        transform.position = shotPoint.transform.position;

        if (playerDir.PlayerRotation.value.y == 0)
            lastDir = 1;
        else if (playerDir.PlayerRotation.value.y < 0)
            lastDir = -1;

        objAnim.SetTrigger("ShotFired");
        Invoke(nameof(OnShotEnd), 5f);
    }

    private void OnDisable()
    {
        objAnim.ResetTrigger("ShotFired");
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(lastDir * 5, 0, 0) * Time.deltaTime;
    }

    private void OnShotEnd()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, transform.forward, 0.2f, enemiesLayer);

        if (hit2D)
        {
            var enemy = hit2D.collider.gameObject;
            enemy.GetComponent<EnemyBase>().OnDamageTaken();

            Invoke(nameof(OnShotEnd), 0.2f);
        }
    }
}