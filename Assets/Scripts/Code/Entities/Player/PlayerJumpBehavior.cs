using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpBehavior : PlayerController
{
    [SerializeField] private Rigidbody2D rb;

    public Rigidbody2D RgBody
    {
        get { return rb; }
        private set { rb = value; }
    }

    [SerializeField] private float _jumpForce;

    private void Start()
    {
        inputManagerInstance.OnJump += OnJump;
    }

    private void OnJump()
    {
        rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _playerAnim.SetTrigger("IsJumping");
    }

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