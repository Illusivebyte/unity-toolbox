using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObservable
{
    public delegate void EventCallbackDelegate(params object[] args);
    string[] GetEventNames();
    System.Type[] GetEventArgs(string eventName);
    void RegisterForEvent(EventCallbackDelegate del, string eventName);
    void UnregisterForEvent(EventCallbackDelegate del, string eventName);
}
