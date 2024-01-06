using UnityEngine;

public class PlayerMovementBehavior : PlayerController
{
    #region Movement variables

    private Vector2 movement;

    [SerializeField] private float _speed;
    [SerializeField] private float _runSpeed;

    #endregion

    #region Movement update

    void Update()
    {
        OnMovement();
    }

    #endregion

    #region Movement behavior function

    private void OnMovement()
    {
        movement = inputManagerInstance.movement;

        // Checking if button for running is pressed - value < 0.5 = false / value > 0.5 = true
        if (inputManagerInstance.isRunning < 0.5f)
            transform.position += new Vector3(movement.x, 0, 0) * _speed * Time.deltaTime;
        else
            transform.position += new Vector3(movement.x, 0, 0) * _runSpeed * Time.deltaTime;
    }

    #endregion
}