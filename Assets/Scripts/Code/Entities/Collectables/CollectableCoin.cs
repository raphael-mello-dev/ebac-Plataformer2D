using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoin : MonoBehaviour
{
    #region Collected coin reference

    public GameEvent OnCoinCollected;

    #endregion

    #region Trigger 2D

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            Collect();
    }

    #endregion

    #region Collect coin function

    private void Collect()
    {
        OnCoinCollected.RaiseEvent(this, 1);
        Destroy(gameObject);
    }

    #endregion
}