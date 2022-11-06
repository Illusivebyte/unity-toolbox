using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Event/New Event")]
public class EventObject : ScriptableObject
{
    public bool debug;
	public delegate void EmptyEventCallBack();
	public List<EventListener> registeredListeners = new List<EventListener>();
    public delegate void EventCallbackDelegate();
    public List<EventCallbackDelegate> registeredDelegates = new List<EventCallbackDelegate>();

	public void RegisterForEvent(EventListener listener)
    {
		registeredListeners.Add (listener);
	}

    public void RegisterForEvent(EventCallbackDelegate del)
    {
        registeredDelegates.Add(del);
    }

	public void UnregisterForEvent(EventListener listener)
    {
		registeredListeners.Remove(listener);
	}

    public void UnRegisterForEvent(EventCallbackDelegate del)
    {
        registeredDelegates.Remove(del);
    }

	public void Activate()
    {
        if(this.debug)
		    Debug.Log ("Activating Event: " + this.name);
        for (int i = registeredListeners.Count-1; i >= 0 ; i--)
        {
            if (registeredListeners[i] != null)
            {
                if (debug)
                    Debug.Log("Event " + this.name + "calling: " + registeredListeners[i].gameObject.name);
                registeredListeners[i].EventActivated();
            }
            else
            {
                registeredListeners.RemoveAt(i);
            }
		}
        for (int i = registeredDelegates.Count-1; i >= 0 ; i--)
        {
            if (registeredDelegates[i] != null)
            {
                if (debug)
                    Debug.Log("Event " + this.name + "calling: " + registeredDelegates[i].Target);
                registeredDelegates[i].Invoke();
            }
            else
            {
                registeredDelegates.RemoveAt(i);
            }
		}
	}
}
