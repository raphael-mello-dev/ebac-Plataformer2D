using UnityEngine;

[RequireComponent (typeof(PlayerRotationBehavior))]
[RequireComponent(typeof(PlayerMovementBehavior))]
[RequireComponent(typeof(PlayerJumpBehavior))]
[RequireComponent(typeof(PlayerHealthBehavior))]
[RequireComponent(typeof(PlayerShootBehavior))]

public class PlayerController : MonoBehaviour
{
    protected PlayerSetup playerSetup;

    protected PlayerInputManager inputManagerInstance;

    protected Animator _playerAnim;

    private void Awake()
    {
        inputManagerInstance = new PlayerInputManager();
        _playerAnim = GetComponent<Animator>();
        playerSetup = Resources.Load<PlayerSetup>("Setup");
    }

    private void Start()
    {
        Debug.Log(playerSetup.isSetupOn);
    }
}