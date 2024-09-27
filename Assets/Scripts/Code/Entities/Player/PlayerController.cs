using UnityEngine;

[RequireComponent (typeof(PlayerRotationBehavior))]
[RequireComponent(typeof(PlayerMovementBehavior))]
[RequireComponent(typeof(PlayerJumpBehavior))]
[RequireComponent(typeof(PlayerHealthBehavior))]
[RequireComponent(typeof(PlayerShootBehavior))]

public class PlayerController : MonoBehaviour
{
    private PlayerSetup playerSetup01;
    private PlayerSetup playerSetup02;
    protected PlayerSetup playerSetup;

    protected PlayerInputManager inputManagerInstance;

    protected Animator _playerAnim;

    private void Awake()
    {
        inputManagerInstance = new PlayerInputManager();
        _playerAnim = GetComponent<Animator>();
        playerSetup01 = Resources.Load<PlayerSetup>("Setup");
        playerSetup02 = Resources.Load<PlayerSetup>("Setup02");

        if (playerSetup01.isSetupOn)
        {
            playerSetup02.isSetupOn = false;
            playerSetup = playerSetup01;
        }
        else
        {
            playerSetup01.isSetupOn = false;
            playerSetup = playerSetup02;
        }
    }

    private void Start()
    {

    }
}