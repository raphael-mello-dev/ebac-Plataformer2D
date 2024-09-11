using UnityEngine;

public class PlayerHealthBehavior : PlayerController
{
    public GameEvent OnPlayerDamaged;

    public void KilledAnimation()
    {
        _playerAnim = FindAnyObjectByType<PlayerController>().gameObject.GetComponent<Animator>();
        _playerAnim.SetTrigger("IsDead");
    }
}