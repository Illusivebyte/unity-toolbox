using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Variable<T> : ScriptableObject, IObservable
{
    public string fileName;
    public virtual Type type{ get;}
    public virtual T Value{ get; set;}
	public bool debug;
    protected List<IObservable.EventCallbackDelegate> changeCallbacks = new List<IObservable.EventCallbackDelegate>();


    protected void OnEnable()
    {
        if (this.fileName == "")
        {
            this.fileName = this.name + ".var";
        }
    }

	protected void ReportChange(){
        if (this.debug)
            Debug.Log("Reporting Change: " + this.name);
        foreach (IObservable.EventCallbackDelegate callback in this.changeCallbacks)
        {
            callback(this.Value);
        }
    }
     
    public abstract void SaveVariable();

    public abstract void LoadVariable();

    public string[] GetEventNames()
    {
        return new string[] { "OnChange" };
    }

    public Type[] GetEventArgs(string eventName)
    {
        return new Type[] { this.type };
    }

    public void RegisterForEvent(IObservable.EventCallbackDelegate del, string eventName)
    {
        this.changeCallbacks.Add(del);
    }

    public void UnregisterForEvent(IObservable.EventCallbackDelegate del, string eventName)
    {
        this.changeCallbacks.Remove(del);
    }

    public void Activate(string eventName, params object[] args)
    {
        this.ReportChange();
    }
}
