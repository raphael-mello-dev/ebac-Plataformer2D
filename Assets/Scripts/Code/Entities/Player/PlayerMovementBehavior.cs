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

        if (movement.x != 0)
        {
            // Checking if button for running is pressed - value < 0.5 = false / value > 0.5 = true
            if (inputManagerInstance.isRunning < 0.5f)
            {
                if (_playerAnim.GetInteger("playerActions") != 1)
                    _playerAnim.SetInteger("playerActions", 1);

                transform.position += new Vector3(movement.x, 0, 0) * _speed * Time.deltaTime;
            }
            else
            {
                if (_playerAnim.GetInteger("playerActions") != 2)
                    _playerAnim.SetInteger("playerActions", 2);

                transform.position += new Vector3(movement.x, 0, 0) * _runSpeed * Time.deltaTime;
            }
        }
        else
        {
            if (_playerAnim.GetInteger("playerActions") != 0)
                _playerAnim.SetInteger("playerActions", 0);
        }
    }

    #endregion
}