using System;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData")]
public class PlayerHealthData : ScriptableObject
{
    [SerializeField] private int numOfLifes;
    public int NumOfLifes
    {
        get {  return numOfLifes; }
        private set {  NumOfLifes = numOfLifes; }
    }

    public int _maxHealth;

    public int _currentHealth;

    private int damage;

    public event Action OnlifesTextDisplayed;

    public GameEvent OnPlayerKilled;

    public void OnDamageTaken(Component sender, object data)
    {
        if (data is int)
        {
            damage = (int)data;
        }
        else
        {
            Debug.LogError("Data needs to be a int");
            return;
        }

        if (_currentHealth - damage > 0)
        {
            _currentHealth -= damage;
            Debug.Log($"Max Health: {_maxHealth} / Current Health: {_currentHealth}");
        }
        else if (numOfLifes > 0)
        {
            numOfLifes--;
            _currentHealth = _maxHealth;
            OnlifesTextDisplayed?.Invoke();

        }
        else
            OnPlayerKilled.RaiseEvent();
    }

    public void OnKilled()
    {
        Debug.Log("Game Over");
        Destroy(GameObject.FindAnyObjectByType<PlayerController>().gameObject, 1.5f);
    }

    public void OnLifeCollected()
    {
        numOfLifes++;
    }
}