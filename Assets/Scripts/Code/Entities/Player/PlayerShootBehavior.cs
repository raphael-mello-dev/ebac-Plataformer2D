using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootBehavior : PlayerController
{
    void Start()
    {
        inputManagerInstance.OnShoot += OnShoot;
    }

    private void Update()
    {
        ShotAnimation();
    }

    private void OnShoot()
    {
        
    }

    private void ShotAnimation()
    {
        if (inputManagerInstance.isShooting > 0.5f)
        {
            if (_playerAnim.GetBool("IsShooting") != true)
                _playerAnim.SetBool("IsShooting", true);
        }
        else
            _playerAnim.SetBool("IsShooting", false);
    }
}
