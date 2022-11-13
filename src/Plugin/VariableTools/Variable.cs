using System.Collections.Generic;
using UnityEngine;

public abstract class Variable : ScriptableObject
{
    public string fileName;
	public enum StandardVariableType{Int, Float, Bool, String, Vector2, Vector3, Quaternion};
    public virtual StandardVariableType type{ get;}
	public bool debug;
	public List<VariableListener> registeredListeners = new List<VariableListener>();
    public delegate void VariableCallbackDelegate();
    public List<VariableCallbackDelegate> registeredDelegates = new List<VariableCallbackDelegate>();
    public delegate void VariableValueChanged();
    public event VariableValueChanged VariableValueChangedEvent;

    protected void OnEnable()
    {
        if (this.fileName == "")
        {
            this.fileName = this.name + ".var";
        }
    }

	public void RegisterForUpdates(VariableListener listener)
    {
		this.registeredListeners.Add (listener);
    }

    public void RegisterForUpdates(VariableCallbackDelegate del)
    {
        this.registeredDelegates.Add (del);
    }

	public void UnregisterForUpdates(VariableListener listener)
    {
		this.registeredListeners.Remove (listener);
	}
		
	public void UnregisterForUpdates(VariableCallbackDelegate del)
    {
        this.registeredDelegates.Remove (del);
    }

	protected  void ReportChange(){
        if (this.debug)
            Debug.Log("Reporting Change: " + this.name);
        if (this.VariableValueChangedEvent != null)
            this.VariableValueChangedEvent.Invoke(); 
        for (int i = registeredListeners.Count-1; i >= 0 ; i--)
        {
            if (registeredListeners[i] == null)
            {
                registeredListeners.RemoveAt(i);
                continue;
            }
            if (debug)
                Debug.Log("Variable " + this.name + "calling: " + registeredListeners[i].gameObject.name);
            registeredListeners[i].VariableUpdated();
		}
        for (int i = registeredDelegates.Count-1; i >= 0 ; i--)
        {
            if (registeredDelegates[i] == null)
            {
                registeredDelegates.RemoveAt(i);
                continue;
            }
            if (debug)
                Debug.Log("Variable " + this.name + "calling: " + registeredDelegates[i].Target);
            registeredDelegates[i].Invoke();
        }
    }
     
    public abstract void SaveVariable();

    public abstract void LoadVariable();
}
