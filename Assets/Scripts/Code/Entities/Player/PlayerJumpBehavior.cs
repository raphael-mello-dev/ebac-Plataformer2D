using UnityEngine;

public class PlayerJumpBehavior : PlayerController
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private ParticleSystem jumpParticle;
    [SerializeField] private AudioSource jumpSound;

    public bool IsJumping { get; private set; }

    public Rigidbody2D RgBody
    {
        get { return rb; }
        private set { rb = value; }
    }

    [SerializeField] private float _jumpForce;

    private void Start()
    {
        IsJumping = false;
        inputManagerInstance.OnJump += OnJump;

        if (playerSetup.isSetupOn)
        {
            _jumpForce = playerSetup.jumpForce;
        }
    }

    private void OnJump()
    {
        rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _playerAnim.SetTrigger("IsJumping");
        jumpParticle.Play();
        jumpSound.Play();
        IsJumping = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            _playerAnim.SetTrigger("OnFloor");
            IsJumping = false;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
            _playerAnim.ResetTrigger("OnFloor");
    }
}