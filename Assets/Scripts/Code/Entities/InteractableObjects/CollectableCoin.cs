using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoin : MonoBehaviour
{
    public event Action OnCoinCollected;

    public HUDManager hudManager;
    [SerializeField] private ParticleSystem coinParticle;
    [SerializeField] private SpriteRenderer coinRenderer;
    [SerializeField] private AudioSource coinCollectSound;

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
        if (coinRenderer.sprite != null)
        {
            OnCoinCollected?.Invoke();
            StartCoroutine(nameof(CoinCollected));
        }        
    }

    private IEnumerator CoinCollected()
    {
        coinParticle.Play();
        coinCollectSound.Play();
        coinRenderer.sprite = null;
        yield return new WaitForSecondsRealtime(3f);
        Destroy(gameObject);
    } 
}