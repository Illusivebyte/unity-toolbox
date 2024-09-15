using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservableGameObject : MonoBehaviour, IObservable
{
    protected Dictionary<string, Dictionary<string, object>> events = new Dictionary<string, Dictionary<string, object>>();

    protected bool CreateEvent(string name, System.Type[] args)
    {
        if (events.ContainsKey(name))
        {
            return false;
        }
        Dictionary<string, object> eventInfo = new Dictionary<string, object>
        {
            { "args", args },
            { "callbacks", new List<IObservable.EventCallbackDelegate>() }
        };
        events.Add(name, eventInfo);
        return true;
    }

    protected bool DeleteEvent(string name)
    {
        if (!events.ContainsKey(name))
        {
            return false;
        }
        events.Remove(name);
        return true;
    }

    public string[] GetEventNames()
    {
        return new List<string>(events.Keys).ToArray();
    }

    public System.Type[] GetEventArgs(string eventName)
    {
        if (!events.ContainsKey(eventName))
        {
            return new System.Type[] { };
        }
        return (System.Type[])events[eventName]["args"];
    }

    public void RegisterForEvent(IObservable.EventCallbackDelegate del, string eventName)
    {
        if (!events.ContainsKey(eventName))
        {
            return;
        }
        ((List<IObservable.EventCallbackDelegate>)events[eventName]["callbacks"]).Add(del);
    }

    public void RegisterForAllEvents(IObservable.EventCallbackDelegate del)
    {
        foreach (string eventName in events.Keys)
        {
            RegisterForEvent(del, eventName);
        }
    }

    public void UnregisterForEvent(IObservable.EventCallbackDelegate del, string eventName)
    {
        if (!events.ContainsKey(eventName))
        {
            return;
        }
        ((List<IObservable.EventCallbackDelegate>)events[eventName]["callbacks"]).Remove(del);
    }

    public void UnregisterForAllEvents(IObservable.EventCallbackDelegate del)
    {
        foreach (string eventName in events.Keys)
        {
            UnregisterForEvent(del, eventName);
        }
    }

    protected void Activate(string eventName, params object[] args)
    {
        if (!events.ContainsKey(eventName))
        {
            return;
        }
        foreach (IObservable.EventCallbackDelegate callback in (List<IObservable.EventCallbackDelegate>)events[eventName]["callbacks"])
        {
            callback(args);
        }
    }

}
