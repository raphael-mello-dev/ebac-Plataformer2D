using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpBehavior : PlayerController
{
    #region Player Rigidbody 2D

    [SerializeField] private Rigidbody2D rb;
    public Rigidbody2D RgBody
    {
        get { return rb; }
        private set { rb = value; }
    }

    #endregion

    #region Jump behavior variable

    [SerializeField] private float _jumpForce;

    #endregion

    #region Jump Setup

    private void Start()
    {
        inputManagerInstance.OnJump += OnJump;
    }

    #endregion

    #region Jump function

    private void OnJump()
    {
        rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _playerAnim.SetTrigger("IsJumping");
    }

    #endregion

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
            _playerAnim.SetTrigger("OnFloor");
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
            _playerAnim.ResetTrigger("OnFloor");
    }
}