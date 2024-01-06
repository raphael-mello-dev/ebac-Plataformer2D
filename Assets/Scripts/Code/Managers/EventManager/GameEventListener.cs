using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CustomGameEvent : UnityEvent<Component, object> { }

public class GameEventListener : MonoBehaviour
{
    #region GameEvent Reference

    public GameEvent gameEvent;

    #endregion

    #region GameEvent Response

    public CustomGameEvent response;

    #endregion

    #region Fuctions to Resgistrate and Remove Event on Listener

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }

    #endregion

    #region Function to Raise an Event

    public void OnEventRaised(Component sender, object data)
    {
        response?.Invoke(sender, data);
    }

    #endregion
}