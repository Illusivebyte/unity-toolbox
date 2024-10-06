using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Event/New Event")]
public class EventObject : ScriptableObject, IObservable
{
    public string eventName;
    public bool debug;
    public Variable<object>[] args;
    public List<IObservable.EventCallbackDelegate> registeredDelegates = new List<IObservable.EventCallbackDelegate>();

    public void OnEnable()
    {
        if (eventName == "")
        {
            eventName = this.name;
        }
    }

    public bool CreateEvent(string name, Type[] args)
    {
        return false;
    }
    public bool DeleteEvent(string name)
    {
        return false;
    }

    public string[] GetEventNames()
    {
        return new string[] { eventName };
    }

    public Type[] GetEventArgs(string eventName)
    {
        Type[] argTypes = new Type[args.Length];
        for (int i = 0; i < args.Length; i++)
        {
            argTypes[i] = args[i].type;
        }
        return argTypes;
    }

    public void RegisterForEvent(IObservable.EventCallbackDelegate del)
    {
        registeredDelegates.Add(del);
    }

    public void UnregisterForEvent(IObservable.EventCallbackDelegate del)
    {
        registeredDelegates.Remove(del);
    }


    public void RegisterForEvent(IObservable.EventCallbackDelegate del, string eventName)
    {
        RegisterForEvent(del);
    }

    public void UnregisterForEvent(IObservable.EventCallbackDelegate del, string eventName)
    {
        UnregisterForEvent(del);
    }

	public void Activate()
    {
        if(this.debug)
		    Debug.Log ("Activating Event: " + this.name);
        for (int i = registeredDelegates.Count-1; i >= 0 ; i--)
        {
            if (registeredDelegates[i] == null)
            {
                registeredDelegates.RemoveAt(i);
                continue;
            }
            if (debug)
                Debug.Log("Event " + this.name + "calling: " + registeredDelegates[i].Target);
            // create array of arg values from args
            object[] argValues = new object[args.Length];
            for (int j = 0; j < args.Length; j++)
            {
                
                argValues[j] = args[j].Value;
            }
            registeredDelegates[i].Invoke(argValues);
        }
	}

	public void Activate(params object[] args)
    {
        if(this.debug)
		    Debug.Log ("Activating Event: " + this.name);
        for (int i = registeredDelegates.Count-1; i >= 0 ; i--)
        {
            if (registeredDelegates[i] == null)
            {
                registeredDelegates.RemoveAt(i);
                continue;
            }
            if (debug)
                Debug.Log("Event " + this.name + "calling: " + registeredDelegates[i].Target);
            // create array of arg values from args
            object[] argValues = new object[args.Length + args.Length];
            for (int j = 0; j < args.Length; j++)
            {
                argValues[j] = args[j];
            }
            registeredDelegates[i].Invoke(argValues);
        }
	}

    public void Activate(string eventName, params object[] args)
    {
        if (this.eventName == eventName)
        {
            Activate(args);
        }
    }
}
