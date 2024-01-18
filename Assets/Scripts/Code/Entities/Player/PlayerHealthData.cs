using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData")]
public class PlayerHealthData : ScriptableObject
{

    #region Player Max Health

    public int _maxHealth;

    #endregion

    #region Player Current Health

    public int _currentHealth;

    #endregion

    #region Damage variable

    private int damage;

    #endregion

    #region Player Killed Event

    public GameEvent OnPlayerKilled;

    #endregion

    #region Player taking damage function

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

    #endregion

    #region Player Killed function

    public void OnKilled()
    {
        Debug.Log("Game Over");
        //Destroy(GameObject.FindAnyObjectByType<PlayerController>().gameObject, 1.5f);
    }

    #endregion
}