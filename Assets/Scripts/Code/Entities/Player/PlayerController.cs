using UnityEngine;

[RequireComponent (typeof(PlayerRotationBehavior))]
[RequireComponent(typeof(PlayerMovementBehavior))]
[RequireComponent(typeof(PlayerJumpBehavior))]
[RequireComponent(typeof(PlayerHealthBehavior))]

public class PlayerController : MonoBehaviour
{
    #region Player Input Manager instance

    protected PlayerInputManager inputManagerInstance;

    #endregion

    #region Player Animator instance

    protected Animator _playerAnim;

    #endregion

    #region Player Setup

    private void Awake()
    {
        inputManagerInstance = new PlayerInputManager();
        _playerAnim = GetComponent<Animator>();
    }

    #endregion
}