using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoin : MonoBehaviour
{
    public event Action OnCoinCollected;

    public HUDManager hudManager;

    private void Start()
    {
        OnCoinCollected += hudManager.CoinCollectedDisplay;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            Collect();
    }

    private void Collect()
    {
        OnCoinCollected?.Invoke();
        Destroy(gameObject);
    }
}