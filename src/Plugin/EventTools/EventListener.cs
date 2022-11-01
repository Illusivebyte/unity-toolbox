using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode]
public class EventListener : MonoBehaviour 
{
	public EventObject registerEvent;
	public UnityEvent eventCallback;
    public bool debug;

	protected void OnEnable()
	{
        if(registerEvent != null)
		    registerEvent.RegisterForEvent(this);
	}

	protected void OnDisable()
	{
        if(registerEvent != null)
		    registerEvent.UnregisterForEvent(this);
	}

	public void EventActivated()
	{
        if(debug)
            Debug.Log (name + " event activated");
		eventCallback.Invoke ();
	}
}
