using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager
{
    #region Player Controls instance

    private PlayerControls playerControls;

    #endregion

    #region Player Input Actions

    public Vector2 movement => playerControls.Gameplay.Walk.ReadValue<Vector2>();

    public event Action OnRun;
    public event Action OnJump;

    #endregion

    #region Player Input Manager Constructor

    public PlayerInputManager()
    {
        playerControls = new PlayerControls();

        playerControls.Gameplay.Enable();

        playerControls.Gameplay.Run.performed += RunPerformed;
        playerControls.Gameplay.Jump.performed += JumpPerformed;
    }

    #endregion

    #region Player Input Invoke functions

    private void RunPerformed(InputAction.CallbackContext context)
    {
        OnRun?.Invoke();
    }

    private void JumpPerformed(InputAction.CallbackContext context)
    {
        OnJump?.Invoke();
    }

    #endregion
}