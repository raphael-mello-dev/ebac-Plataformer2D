using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableLife : MonoBehaviour
{
    public event Action OnLifeCollected;

    public PlayerHealthData playerHealthData;
    public HUDManager hudManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnLifeCollected?.Invoke();
            OnLifeCollected = null;
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        OnLifeCollected += playerHealthData.OnLifeCollected;
        OnLifeCollected += hudManager.LifeCollectedDisplay;
    }
}
