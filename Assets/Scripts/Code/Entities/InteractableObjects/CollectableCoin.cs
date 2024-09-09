using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoin : MonoBehaviour
{
    public GameEvent OnCoinCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            Collect();
    }

    private void Collect()
    {
        OnCoinCollected.RaiseEvent(this, 1);
        Destroy(gameObject);
    }
}