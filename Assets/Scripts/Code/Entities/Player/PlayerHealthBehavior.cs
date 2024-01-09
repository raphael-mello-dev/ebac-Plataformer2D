using UnityEngine;

public class PlayerHealthBehavior : MonoBehaviour
{
    public GameEvent OnPlayerDamaged;

    public PlayerHealthData playerHealth;

    void Start()
    {
        Debug.Log($"Max Health: {playerHealth._maxHealth} / Current Health: {playerHealth._currentHealth}");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            OnPlayerDamaged.RaiseEvent(this, 2);
        }
    }
}