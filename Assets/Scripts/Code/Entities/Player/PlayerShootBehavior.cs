using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootBehavior : PlayerController
{
    [SerializeField] private PoolManager poolManager;

    [SerializeField] private Transform shotPoint;

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
        Invoke(nameof(OnShotStart), 0.75f);
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

    private void OnShotStart()
    {
        var obj = poolManager.GetPooledObjects();
        obj.SetActive(true);
    }
}
