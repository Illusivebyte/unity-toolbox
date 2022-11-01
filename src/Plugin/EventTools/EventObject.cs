using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Event/New Event")]
public class EventObject : ScriptableObject
{
    public bool debug;
	public delegate void EmptyEventCallBack();
	public List<EventListener> registeredListeners = new List<EventListener>();

	public void RegisterForEvent(EventListener listener){
		registeredListeners.Add (listener);
	}

	public void UnregisterForEvent(EventListener listener){
		registeredListeners.Remove (listener);
	}

	public void Activate()
    {
        if(this.debug)
		    Debug.Log ("Activating Event: " + this.name);
        for (int i = this.registeredListeners.Count-1; i >= 0 ; i--)
        {
            if (this.registeredListeners[i] != null)
            {
                if (this.debug)
                    Debug.Log("Event " + this.name + "calling: " + this.registeredListeners[i].gameObject.name);
                registeredListeners[i].EventActivated();
            }
            else
            {
                registeredListeners.RemoveAt(i);
            }
		}
	}
}
