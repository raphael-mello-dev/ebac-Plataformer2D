using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] Transform player;

    void Start() { }

    void Update()
    {
        if (player.position.x < -70)
            transform.position = new Vector3(-70, transform.position.y, transform.position.z);
        else if (player.position.x > 97)
            transform.position = new Vector3(97, transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}