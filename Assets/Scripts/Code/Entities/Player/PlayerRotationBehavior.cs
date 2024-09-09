using Unity.Mathematics;
using UnityEngine;

public class PlayerRotationBehavior : PlayerController
{
    public quaternion PlayerRotation
    {
        private set { PlayerRotation = transform.rotation; }
        get { return transform.rotation; }
    }

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