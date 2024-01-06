using UnityEngine;

public class PlayerRotationBehavior : PlayerController
{
    #region Rotation update

    void Update()
    {
        OnRotate();
    }

    #endregion

    #region Rotation function

    private void OnRotate()
    {
        if (inputManagerInstance.movement.x > 0)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else if (inputManagerInstance.movement.x < 0)
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }

    #endregion
}