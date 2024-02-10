using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager
{
    private PlayerControls playerControls;

    public Vector2 movement => playerControls.Gameplay.Walk.ReadValue<Vector2>();
    public float isRunning => playerControls.Gameplay.Run.ReadValue<float>();
    public float isShooting => playerControls.Gameplay.Shoot.ReadValue<float>();

    public event Action OnRun;
    public event Action OnJump;
    public event Action OnShoot;

    public PlayerInputManager()
    {
        playerControls = new PlayerControls();

        playerControls.Gameplay.Enable();

        playerControls.Gameplay.Run.performed += RunPerformed;
        playerControls.Gameplay.Jump.performed += JumpPerformed;
        playerControls.Gameplay.Shoot.performed += ShootPerformed;
    }

    private void RunPerformed(InputAction.CallbackContext context)
    {
        OnRun?.Invoke();
    }

    private void JumpPerformed(InputAction.CallbackContext context)
    {
        OnJump?.Invoke();
    }

    private void ShootPerformed(InputAction.CallbackContext context)
    {
        OnShoot?.Invoke();
    }
}