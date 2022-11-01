using System.Collections.Generic;
using UnityEngine;

public abstract class Variable : ScriptableObject
{
    public string fileName;
	public enum StandardVariableType{Int, Float, Bool, String, Vector2, Vector3, Quaternion};
    public virtual StandardVariableType type{ get;}
	public bool debug;
	public List<VariableListener> registeredListeners = new List<VariableListener>();
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

	public void UnregisterForUpdates(VariableListener listener)
    {
		this.registeredListeners.Remove (listener);
	}
		
	protected  void ReportChange(){
        if (this.debug)
            Debug.Log("Reporting Change: " + this.name);
        if (this.VariableValueChangedEvent != null)
            this.VariableValueChangedEvent.Invoke();
        VariableListener[] variableListener = this.registeredListeners.ToArray();
        for (int i = 0; i < variableListener.Length; i++)
        {
            variableListener[i].VariableUpdated();
        }
    }
     
    public abstract void SaveVariable();

    public abstract void LoadVariable();
}
