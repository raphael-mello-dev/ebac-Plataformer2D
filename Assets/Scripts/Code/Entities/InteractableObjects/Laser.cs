using UnityEngine;

public class Laser : MonoBehaviour
{
    private Animator objAnim;

    private PlayerRotationBehavior playerDir;
    private float lastDir;

    private GameObject shotPoint;

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

        Debug.Log(playerDir.PlayerRotation);
        Debug.Log(lastDir);
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
}