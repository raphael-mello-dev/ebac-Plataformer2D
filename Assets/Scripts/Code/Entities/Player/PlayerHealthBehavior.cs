using UnityEngine;

public class PlayerHealthBehavior : PlayerController
{
    public GameEvent OnPlayerDamaged;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            OnPlayerDamaged.RaiseEvent(this, 2);
        }
    }

    #region Player killed animation function

    public void KilledAnimation()
    {
        _playerAnim = FindAnyObjectByType<PlayerController>().gameObject.GetComponent<Animator>();
        _playerAnim.SetTrigger("IsDead");
    }

    #endregion
}