using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData")]
public class PlayerHealthData : ScriptableObject
{
    public int _maxHealth;

    public int _currentHealth;

    private int damage;

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
        else
            OnPlayerKilled.RaiseEvent();
    }

    public void OnKilled()
    {
        Debug.Log("Game Over");
        //Destroy(GameObject.FindAnyObjectByType<PlayerController>().gameObject, 1.5f);
    }
}