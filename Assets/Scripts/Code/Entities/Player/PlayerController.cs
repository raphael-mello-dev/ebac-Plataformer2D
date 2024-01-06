using UnityEngine;

[RequireComponent (typeof(PlayerRotationBehavior))]
[RequireComponent(typeof(PlayerMovementBehavior))]

public class PlayerController : MonoBehaviour
{
    #region Player Input Manager instance

    protected PlayerInputManager inputManagerInstance;

    #endregion

    #region Player Setup

    private void Awake()
    {
        inputManagerInstance = new PlayerInputManager();
    }

    #endregion
}
