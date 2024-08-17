using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsHolder : MonoBehaviour
{
    #region Singleton
    public static EventsHolder instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public UnityEvent[] events;

    public void InvokeEvent(int eventId)
    {
        events[eventId].Invoke();
    }
}
