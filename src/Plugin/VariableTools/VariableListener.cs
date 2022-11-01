using UnityEngine;
using UnityEngine.Events;

public class VariableListener : MonoBehaviour
{
	public  Variable trackingVariable;
	public UnityEvent eventCallback;

	public virtual void VariableUpdated()
	{
		this.eventCallback.Invoke ();
	}

	protected virtual void OnEnable()
	{
		this.trackingVariable.RegisterForUpdates(this);
	}

	protected virtual void OnDisable()
	{
		this.trackingVariable.UnregisterForUpdates(this);
	}
}
