using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameEvent")]
public class GameEvent : ScriptableObject
{
    #region List of Listeners

    public List<GameEventListener> listeners = new List<GameEventListener>();

    #endregion

    #region Registration functions

    public void RegisterListener(GameEventListener listener)
    {
        if (!listeners.Contains(listener))
            listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        if (!listeners.Contains(listener))
            listeners.Remove(listener);
    }

    #endregion

    #region Function to Raise all Events

    public void RaiseEvent(Component sender, object data)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(sender, data);
    }

    #endregion
}