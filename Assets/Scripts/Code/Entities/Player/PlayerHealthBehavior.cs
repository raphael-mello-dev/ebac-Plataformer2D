using UnityEngine;

public class PlayerHealthBehavior : PlayerController
{
    public GameEvent OnPlayerDamaged;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            OnPlayerDamaged.RaiseEvent(this, 2);
        }
    }

    public void KilledAnimation()
    {
        _playerAnim = FindAnyObjectByType<PlayerController>().gameObject.GetComponent<Animator>();
        _playerAnim.SetTrigger("IsDead");
    }
}